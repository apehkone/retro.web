using System.Threading.Tasks;
using Commando.Core;
using Commando.Core.Attributes;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;

namespace Retro.Domain.Commands
{
    [CommandHandler]
    public class UpdateRetrospectiveItemHandler : ICommandHandler<UpdateRetrospectiveItemCommand, EntityCommandResult<RetrospectiveItem>>
    {
        private readonly IDocumentRepository<Retrospective> repository;

        public UpdateRetrospectiveItemHandler(IDocumentRepository<Retrospective> repository) {
            this.repository = repository;
        }

        public EntityCommandResult<RetrospectiveItem> Execute(UpdateRetrospectiveItemCommand source) {
            return ExecuteAsync(source).Result;
        }

        public async Task<EntityCommandResult<RetrospectiveItem>> ExecuteAsync(UpdateRetrospectiveItemCommand source) {
            var retroItem = new RetrospectiveItem
                            {
                                Votes = source.Votes,
                                Description = source.Description
                            };

            StoredProcedureResponse<dynamic> procresult = await repository.ExecuteStoredProc("UpdateRetrospectiveItem", new dynamic[] {source.RetrospectiveId, source.CategoryId, retroItem});
            return new EntityCommandResult<RetrospectiveItem> {Response = procresult};
        }
    }
}