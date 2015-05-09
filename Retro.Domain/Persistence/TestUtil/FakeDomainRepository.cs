using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;

namespace Retro.Domain.Persistence.TestUtil
{
    public class FakeDomainRepository : IDocumentRepository<Retrospective>
    {
        static readonly IDictionary<string, Retrospective> db = new Dictionary<string, Retrospective>();
        static bool initialized;

        public FakeDomainRepository() {
            if (initialized) {
                return;
            }

            var item = new Retrospective
                       {
                           Id = Guid.NewGuid().ToString(),
                           CreatedOn = DateTime.Now,
                           UpdatedOn = DateTime.Now,
                           Description = "Sprint 20 Retro",
                           Categories = new[]
                                        {
                                            new RetrospectiveItemCategory
                                            {
                                                Description = "Action items",
                                                Items = new[]
                                                        {
                                                            new RetrospectiveItem
                                                            {
                                                                Description = "Do something awesome",
                                                                Id = Guid.NewGuid().ToString(),
                                                                Votes = 1
                                                            },
                                                            new RetrospectiveItem
                                                            {
                                                                Description = "Fix this please",
                                                                Id = Guid.NewGuid().ToString(),
                                                                Votes = 0
                                                            }
                                                        }
                                            },
                                            new RetrospectiveItemCategory
                                            {
                                                Description = "Good items",
                                                Items = new[]
                                                        {
                                                            new RetrospectiveItem
                                                            {
                                                                Description = "This item went really well!",
                                                                Id = Guid.NewGuid().ToString(),
                                                                Votes = 2
                                                            }
                                                        }
                                            },
                                            new RetrospectiveItemCategory
                                            {
                                                Description = "Bad items",
                                                Items = new[]
                                                        {
                                                            new RetrospectiveItem
                                                            {
                                                                Description = "This didn't go quite as planned",
                                                                Id = Guid.NewGuid().ToString(),
                                                                Votes = 0
                                                            }
                                                        }
                                            }
                                        }
                       };

            db.Add(item.Id, item);

            initialized = true;
        }


        public Retrospective GetById(string id) {
            return db.ContainsKey(id) ? db[id] : null;
        }

        Task<ResourceResponse<Document>> IDocumentRepository<Retrospective>.Save(Retrospective item) {
            if (item.Id == Guid.Empty.ToString()) {
                var id = Guid.NewGuid().ToString();
                item.Id = id;
                item.CreatedOn = DateTime.Now;
            }
            item.UpdatedOn = DateTime.Now;

            db.Add(item.Id, item);
            return null;
        }

        public Task<ResourceResponse<Document>> Update(Retrospective item) {
            return null;
        }

        public Task<ResourceResponse<Document>> Delete(Retrospective item) {
            db.Remove(item.Id);
            return null;
        }

        public IEnumerable<Retrospective> Get(Func<Retrospective, bool> filter = null) {
            var result = db.Values.Where(a => true);

            if (filter != null) {
                result = result.Where(filter);
            }

            return result;
        }

        public Task<StoredProcedureResponse<dynamic>> ExecuteStoredProc(string procedure, dynamic[] parameters) {
            return null;
        }
    }
}