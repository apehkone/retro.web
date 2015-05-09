using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Retro.Domain.Util;

namespace Retro.Domain.Persistence
{
    public class DbContext : IDbContext
    {
        private readonly DocumentClient client;
        private readonly IDbConfig config;
        private Database database;
        private DocumentCollection documentCollection;

        public DbContext(IDbConfig config) {
            this.config = config;
            client = new DocumentClient(new Uri(config.EndpointUrl), config.AuthorizationKey);
            GetOrCreateDatabase(config.DataBaseId);
            GetOrCreateDocumentCollection();
            CreateStoredProcedures();
        }

        public DocumentClient Client { get { return client; } }
        public Database Database { get { return database; } }
        public DocumentCollection DocumentCollection { get { return documentCollection; } }

        private void GetOrCreateDocumentCollection() {
            DocumentCollection result = client.CreateDocumentCollectionQuery(database.SelfLink).Where(c => c.Id == config.DocumentCollectionId).ToArray().FirstOrDefault();
            documentCollection = result ?? client.CreateDocumentCollectionAsync(database.CollectionsLink, new DocumentCollection {Id = config.DocumentCollectionId}).Result;
        }

        private void GetOrCreateDatabase(string id) {
            database = client.CreateDatabaseQuery().Where(db => db.Id == id).ToArray().FirstOrDefault() ?? client.CreateDatabaseAsync(new Database {Id = id}).Result;
        }

        public void CreateStoredProcedures() {

            IList<Task> tasks = new List<Task>();

            foreach (string resourceName in Assembly.GetExecutingAssembly().FindEmbeddedFile(".js")) {
                string[] splitName = resourceName.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries);

                var sproc = new StoredProcedure
                            {
                                Id = splitName[splitName.Length - 2],
                                Body = Assembly.GetExecutingAssembly().ReadEmbeddedFile(resourceName)
                            };

                TryDeleteStoredProcedure(documentCollection.SelfLink, sproc.Id);
                tasks.Add(client.CreateStoredProcedureAsync(documentCollection.SelfLink, sproc));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private void TryDeleteStoredProcedure(string colSelfLink, string sprocId) {
            StoredProcedure sproc = FindStoredProcById(colSelfLink, sprocId);

            if (sproc != null) {
                client.DeleteStoredProcedureAsync(sproc.SelfLink).Wait();
            }
        }

        protected StoredProcedure FindStoredProcById(string colSelfLink, string sprocId) {
            return client.CreateStoredProcedureQuery(colSelfLink).Where(s => s.Id == sprocId).AsEnumerable().FirstOrDefault();
        }
    }
}