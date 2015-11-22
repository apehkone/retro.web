using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Retro.Web.api.hubs
{
    [HubName("retroHub")]
    public class RetroHub : Hub
    {
        public Task Subscribe(string boardId) {
            return Groups.Add(Context.ConnectionId, boardId);
        }

        public void Notify(RetroEvent evnt) {
            Clients.OthersInGroup(evnt.BoardId).notify(evnt);
        }
    }

    public class RetroEvent
    {
        [JsonProperty("boardId")]
        public string BoardId { get; set; }

        [JsonProperty("retroId")]
        public string RetroId { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonConverter(typeof (StringEnumConverter))]
        [JsonProperty("action")]
        public RetroAction Action { get; set; }
    }


    public enum RetroAction
    {
        Unknown,
        Save,
        Update,
        Delete,
        Vote
    }
}