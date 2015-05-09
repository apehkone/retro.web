using System;
using System.Threading.Tasks;
using Commando.Core;
using Commando.Core.Attributes;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;

namespace Retro.Domain.Commands
{
    [CommandHandler]
    public class CreateOrUpdateRetrospectiveItemHandler : ICommandHandler<CreateOrUpdateRetrospectiveItemCommand, EntityCommandResult<RetrospectiveItem>>
    {
        private readonly IDocumentRepository<Retrospective> repository;

        public CreateOrUpdateRetrospectiveItemHandler(IDocumentRepository<Retrospective> repository) {
            this.repository = repository;
        }

        public EntityCommandResult<RetrospectiveItem> Execute(CreateOrUpdateRetrospectiveItemCommand source) {
            return ExecuteAsync(source).Result;
        }

        public async Task<EntityCommandResult<RetrospectiveItem>> ExecuteAsync(CreateOrUpdateRetrospectiveItemCommand source) {
            string storedProcName = string.IsNullOrEmpty(source.RetrospectiveItemId) ? "InsertRetrospectiveItem" : "UpdateRetrospectiveItem";

            var retroItem = new RetrospectiveItem
                            {
                                Votes = source.Votes,
                                Description = source.Description,
                                Id = string.IsNullOrEmpty(source.RetrospectiveItemId) ? Guid.NewGuid().ToString() : source.RetrospectiveItemId
                            };

            try {
                StoredProcedureResponse<dynamic> procresult = await repository.ExecuteStoredProc(storedProcName, new dynamic[] {source.RetrospectiveId, source.CategoryId, retroItem});
                return new EntityCommandResult<RetrospectiveItem> {Response = procresult, Entity = retroItem, IsSuccess = true};
            }
            catch (Exception ex) {
                return new EntityCommandResult<RetrospectiveItem> {IsSuccess = false, Response = ex};
            }
        }
    }
}