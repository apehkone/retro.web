using System;
using NUnit.Framework;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;

namespace Retro.Tests.Domain
{
    public class DomainRepositoryTestBase : IDbConfig
    {
        protected IDocumentRepository<Retrospective> repository;
        private const string ENDPOINT_URL = @"https://retro.documents.azure.com:443/";
        private const string AUTHORIZATION_KEY = "9XJDrY6gYQXnSX+WWtNIr66fvEwRbvU98opG5owV5+4MRQoThVf7LLyq7cgABSeYnSy48+ek+oNcBUqDjr3lDw==";
        private const string DATA_BASE_ID = "RetroDbTests";
        private const string DOCUMENT_COLLECTION_ID = "RetroDbTests.Collection";
        public string EndpointUrl { get { return ENDPOINT_URL; } }
        public string AuthorizationKey { get { return AUTHORIZATION_KEY; } }
        public string DataBaseId { get { return DATA_BASE_ID; } }
        public string DocumentCollectionId { get { return DOCUMENT_COLLECTION_ID; } }

        [SetUp]
        public void SetUp() {
            var context = new DbContext(this);
            repository = new DocumentRepository<Retrospective>(context);
        }

        public static Retrospective CreateItem() {
            return new Retrospective
                   {
                       Id = Guid.NewGuid().ToString(),
                       CreatedOn = DateTime.Now,
                       UpdatedOn = DateTime.Now,
                       Description = "Sprint 20 Retro",
                       Categories = new[]
                                    {
                                        new RetrospectiveItemCategory
                                        {
                                            Description = "What should be tried next?",
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
                                            Description = "What went well?",
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
                                            Description = "What needs to be improved?",
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
        }
    }
}