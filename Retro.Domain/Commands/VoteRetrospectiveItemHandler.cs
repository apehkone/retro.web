using System.Threading.Tasks;
using Commando.Core;
using Commando.Core.Attributes;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;

namespace Retro.Domain.Commands
{
    [CommandHandler]
    public class VoteRetrospectiveItemHandler : ICommandHandler<VoteRetrospectiveItemCommand, CommandResult>
    {
        private readonly IDocumentRepository<Retrospective> repository;

        public VoteRetrospectiveItemHandler(IDocumentRepository<Retrospective> repository) {
            this.repository = repository;
        }

        public CommandResult Execute(VoteRetrospectiveItemCommand source) {
            return ExecuteAsync(source).Result;
        }

        public async Task<CommandResult> ExecuteAsync(VoteRetrospectiveItemCommand source) {
            await repository.ExecuteStoredProc("VoteRetrospectiveItem", new dynamic[] {source.RetrospectiveId, source.CategoryId, source.ItemId});
            return CommandResult.Success();
        }
    }
}