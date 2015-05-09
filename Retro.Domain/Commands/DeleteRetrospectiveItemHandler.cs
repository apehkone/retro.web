using System.Threading.Tasks;
using Commando.Core;
using Commando.Core.Attributes;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;

namespace Retro.Domain.Commands
{
    [CommandHandler]
    public class DeleteRetrospectiveItemHandler : ICommandHandler<DeleteRetrospectiveItemCommand, CommandResult>
    {
        private readonly IDocumentRepository<Retrospective> repository;

        public DeleteRetrospectiveItemHandler(IDocumentRepository<Retrospective> repository) {
            this.repository = repository;
        }


        public CommandResult Execute(DeleteRetrospectiveItemCommand source) {
            return ExecuteAsync(source).Result;
        }

        public async Task<CommandResult> ExecuteAsync(DeleteRetrospectiveItemCommand source) {
            StoredProcedureResponse<dynamic> procresult = await repository.ExecuteStoredProc("DeleteRetrospectiveItem", new dynamic[] {source.RetrospectiveId, source.CategoryId, source.RetrospectiveItemId});
            return new CommandResult {Response = procresult};
        }
    }
}