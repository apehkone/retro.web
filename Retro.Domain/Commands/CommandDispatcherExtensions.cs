using System.Threading.Tasks;
using Commando.Core;
using Retro.Domain.Entities;

namespace Retro.Domain.Commands
{
    public static class CommandDispatcherExtensions
    {
        public async static Task<EntityCommandResult<RetrospectiveItem>> CreateRetrospectiveItemAsync(this ICommandDispatcher dispatcher, CreateOrUpdateRetrospectiveItemCommand command) {
            return await dispatcher.DispatchAsync<CreateOrUpdateRetrospectiveItemCommand, EntityCommandResult<RetrospectiveItem>>(command);
        }

        public async static Task<CommandResult> VoteRetrospectiveItemAsyn(this ICommandDispatcher dispatcher, VoteRetrospectiveItemCommand command) {
            return await dispatcher.DispatchAsync<VoteRetrospectiveItemCommand, CommandResult>(command);
        }

        public async static Task<CommandResult> DeleteRetrospectiveItemAsync(this ICommandDispatcher dispatcher, DeleteRetrospectiveItemCommand command) {
            return await dispatcher.DispatchAsync<DeleteRetrospectiveItemCommand, CommandResult>(command);
        }
    }
}