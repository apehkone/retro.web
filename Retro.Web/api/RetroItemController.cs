using System.Threading.Tasks;
using System.Web.Http;
using Commando.Core;
using Retro.Domain.Commands;
using Retro.Domain.Entities;
using Retro.Web.Models;

namespace Retro.Web.api
{
    [RoutePrefix("api/retroitem")]
    public class RetroItemController : ApiController
    {
        readonly ICommandDispatcher commandDispatcher;

        public RetroItemController(ICommandDispatcher commandDispatcher) {
            this.commandDispatcher = commandDispatcher;
        }

        [Route]
        public async Task<dynamic> Post(RetrospectiveItemModel value) {
            var command = new CreateOrUpdateRetrospectiveItemCommand
                          {
                              Description = value.Description,
                              CategoryId = value.CategoryId,
                              RetrospectiveId = value.RetrospectiveId,
                              RetrospectiveItemId = value.Id,
                              Votes = value.Votes
                          };
            EntityCommandResult<RetrospectiveItem> result = await commandDispatcher.CreateRetrospectiveItemAsync(command);
            return new {id = result.Entity.Id};
        }

        [Route]
        public async void Put(RetrospectiveItemModel value) {
            await Post(value);
        }

        [Route("{id:guid}")]
        public async Task<dynamic> Delete(string id, string categoryId, string retrospectiveId) {
            return await commandDispatcher.DeleteRetrospectiveItemAsync(new DeleteRetrospectiveItemCommand {RetrospectiveItemId = id, CategoryId = categoryId, RetrospectiveId = retrospectiveId});
        }
    }
}