using System.Threading.Tasks;
using System.Web.Http;
using Commando.Core;
using Retro.Domain.Commands;
using Retro.Web.Models;

namespace Retro.Web.api
{
    [RoutePrefix("api/vote")]
    public class VoteController : ApiController
    {
        readonly ICommandDispatcher commandDispatcher;

        public VoteController(ICommandDispatcher commandDispatcher) {
            this.commandDispatcher = commandDispatcher;
        }

        [Route]
        public async Task<dynamic> Post(RetrospectiveItemModel value) {
            var command = new VoteRetrospectiveItemCommand
                          {
                              CategoryId = value.CategoryId,
                              RetrospectiveId = value.RetrospectiveId,
                              ItemId = value.Id,
                          };

            return await commandDispatcher.VoteRetrospectiveItemAsyn(command);
        }
    }
}