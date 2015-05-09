using System;

namespace Retro.Web.Models
{
    public class RetrospectiveItemModel
    {
        public string Id { get; set; }
        public string RetrospectiveId { get; set; }
        public string CategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
    }
}