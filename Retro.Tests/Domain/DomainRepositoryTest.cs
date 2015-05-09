using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using NUnit.Framework;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;

namespace Retro.Tests.Domain
{
    [TestFixture]
    public class DomainTests : DomainRepositoryTestBase
    {
        [Test]
        public async void ShouldUpdateRetroDescriptionByStoredProc() {
            Retrospective retro = CreateItem();
            await repository.Save(retro);

            retro.Description = "Updated description";
            StoredProcedureResponse<dynamic> procresult = await repository.ExecuteStoredProc("UpdateRetrospective", new dynamic[] {retro});
            Assert.IsTrue(procresult.Response);
            Retrospective savedRetro = repository.Get(r => r.Id == retro.Id).FirstOrDefault();
            Assert.IsNotNull(savedRetro);
            Assert.AreEqual("Updated description", savedRetro.Description);
        }


        [Test]
        public async void ShouldUpdateGoodItemByStoredProc() {
            Retrospective retro = CreateItem();
            await repository.Save(retro);

            RetrospectiveItem retroItem = retro.Categories[0].Items[0];
            retroItem.Votes += 1;
            retroItem.Description = "Updated item description";
            StoredProcedureResponse<dynamic> procresult = await repository.ExecuteStoredProc("UpdateRetrospectiveItem", new dynamic[] {retro.Id, retro.Categories[0].Id, retroItem});
            Assert.IsNotNull(procresult);
            Retrospective savedRetro = repository.Get(r => r.Id == retro.Id).FirstOrDefault();
            Assert.IsNotNull(savedRetro);
            Assert.AreEqual("Updated item description", savedRetro.Categories[0].Items[0].Description);
        }

        [Test]
        public async void ShouldInsertItemBySproc() {
            Retrospective retro = CreateItem();
            await repository.Save(retro);

            var retroItem = new RetrospectiveItem();
            retroItem.Votes += 1;
            retroItem.Description = "Inserted item description";
            StoredProcedureResponse<dynamic> procresult = await repository.ExecuteStoredProc("InsertRetrospectiveItem", new dynamic[] {retro.Id, retro.Categories[0].Id, retroItem});
            Assert.IsNotNull(procresult);
            Retrospective savedRetro = repository.Get(r => r.Id == retro.Id).FirstOrDefault();
            Assert.IsNotNull(savedRetro);
            Assert.AreEqual("Inserted item description", savedRetro.Categories[0].Items.First(r => r.Id == retroItem.Id).Description);
        }
    }


    [TestFixture]
    public class DomainRepositoryTest : DomainRepositoryTestBase
    {
        [Test]
        public void ShouldDoBasicOperations() {
            AssertSave(repository);
            AssertUpdate(repository);
            AssertQuery(repository);
            AssertDelete(repository);
            AssertStoredProcedures(repository);
        }

        private async void AssertStoredProcedures(IDocumentRepository<Retrospective> context) {
            StoredProcedureResponse<dynamic> response = await context.ExecuteStoredProc("HelloWorld", null);
            Assert.IsNotNull(response.Response, "Hello, World");
        }

        private async void AssertDelete(IDocumentRepository<Retrospective> context) {
            foreach (Retrospective retro in context.Get()) {
                await context.Delete(retro);
            }
            Assert.AreEqual(0, context.Get().Count());
        }

        private async void AssertQuery(IDocumentRepository<Retrospective> context) {
            Retrospective item = CreateItem();
            item.Description = "SearchString";
            await context.Save(item);
            IEnumerable<Retrospective> result = context.Get(r => r.Description == "SearchString");
            Assert.AreEqual(1, result.Count());
        }

        private async void AssertUpdate(IDocumentRepository<Retrospective> context) {
            Retrospective retro = context.Get().FirstOrDefault();
            Assert.IsNotNull(retro);

            retro.Description = "Updated description";
            await context.Update(retro);

            Retrospective updatedRetro = context.Get().FirstOrDefault();
            Assert.IsNotNull(updatedRetro);

            Assert.AreEqual("Updated description", updatedRetro.Description);
        }


        private static async void AssertSave(IDocumentRepository<Retrospective> context) {
            Retrospective item = CreateItem();
            await context.Save(item);
            IEnumerable<Retrospective> result = context.Get();
            Assert.AreEqual(1, result.Count());
        }

        [Test, Explicit]
        public async void ShouldClearDb() {
            foreach (Retrospective retro in repository.Get()) {
                await repository.Delete(retro);
            }

            Assert.AreEqual(0, repository.Get().Count());
        }
    }
}