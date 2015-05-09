using Newtonsoft.Json;

namespace Retro.Domain.Entities
{
    public class RetrospectiveItem : ChildEntity
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }
    }
}