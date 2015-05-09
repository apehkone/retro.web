using System;
using Newtonsoft.Json;

namespace Retro.Domain.Entities
{
    public interface IEntityBase
    {
        string Id { get; set; }
        DateTime? CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }

    public class ChildEntity : IEntityBase
    {
        private string id = Guid.NewGuid().ToString();
        private DateTime? createdOn = DateTime.UtcNow;
        private DateTime? updatedOn = DateTime.UtcNow;
        
        [JsonProperty("id")]
        public string Id { get { return id; } set { id = value; } }

        [JsonProperty("createdOn")]
        public DateTime? CreatedOn { get { return createdOn; } set { createdOn = value; } }

        [JsonProperty("updatedOn")]
        public DateTime? UpdatedOn { get { return updatedOn; } set { updatedOn = value; } }
    }
}