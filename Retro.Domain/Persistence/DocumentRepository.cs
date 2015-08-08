using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Polly;
using Retro.Domain.Entities;

namespace Retro.Domain.Persistence
{
    public class DocumentRepository<TDocument> : IDocumentRepository<TDocument> where TDocument : DocumentEntityBase
    {
        readonly IDbContext ctx;
        readonly ILog log = LogManager.GetLogger(typeof (DocumentRepository<>));

        public DocumentRepository(IDbContext ctx) {
            this.ctx = ctx;
        }

        readonly IDictionary<string, string> storedProcedures = new Dictionary<string, string>();

        public async Task<ResourceResponse<Document>> Save(TDocument item) {
            item.CreatedOn = DateTime.UtcNow;
            item.UpdatedOn = DateTime.UtcNow;
            item.Id = Guid.NewGuid().ToString();
            return await ctx.Client.CreateDocumentAsync(ctx.DocumentCollection.SelfLink, item);
        }

        public IEnumerable<TDocument> Get(Func<TDocument, bool> filter = null) {
            return filter != null ? ctx.Client.CreateDocumentQuery<TDocument>(ctx.DocumentCollection.SelfLink).Where(filter) : ctx.Client.CreateDocumentQuery<TDocument>(ctx.DocumentCollection.SelfLink);
        }

        public async Task<ResourceResponse<Document>> Update(TDocument item) {
            item.UpdatedOn = DateTime.UtcNow;
            var result = await ctx.Client.ReplaceDocumentAsync(item.SelfLink, item);
            return result;
        }

        public async Task<ResourceResponse<Document>> Delete(TDocument item) {
            return await ctx.Client.DeleteDocumentAsync(item.SelfLink);
        }

        public async Task<StoredProcedureResponse<dynamic>> ExecuteStoredProc(string procedure, dynamic[] parameters) {
            var storedProcSelfLink = ResolveStoredProcSelfLink(procedure);

            try {
                var policy = Policy.Handle<DocumentClientException>().WaitAndRetryAsync(new[]
                                                                      {
                                                                          TimeSpan.FromSeconds(1),
                                                                          TimeSpan.FromSeconds(2),
                                                                          TimeSpan.FromSeconds(3)
                                                                      });

                return await policy.ExecuteAsync(() => ctx.Client.ExecuteStoredProcedureAsync<dynamic>(storedProcSelfLink, parameters));
            }
            catch (Exception ex) {
                log.Error(ex);
                throw;
            }
        }

        private string ResolveStoredProcSelfLink(string procedure) {
            string storedProcSelfLink;

            if (storedProcedures.ContainsKey(procedure)) {
                storedProcSelfLink = storedProcedures[procedure];
            }
            else {
                var sproc = FindStoredProcById(ctx.DocumentCollection.SelfLink, procedure);
                if (sproc == null) {
                    throw new Exception(String.Format("Stored procedure {0} cannot be found!", procedure));
                }
                storedProcSelfLink = sproc.SelfLink;
            }
            return storedProcSelfLink;
        }

        protected StoredProcedure FindStoredProcById(string colSelfLink, string sprocId) {
            return ctx.Client.CreateStoredProcedureQuery(colSelfLink).Where(s => s.Id == sprocId).AsEnumerable().FirstOrDefault();
        }
    }
}