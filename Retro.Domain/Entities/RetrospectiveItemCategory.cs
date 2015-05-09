using System.Collections.Generic;
using Newtonsoft.Json;

namespace Retro.Domain.Entities
{
    public class RetrospectiveItemCategory : ChildEntity
    {
        [JsonProperty("items")]
        public IList<RetrospectiveItem> Items { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}