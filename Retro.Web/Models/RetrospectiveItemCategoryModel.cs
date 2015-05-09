using System;
using System.Collections.Generic;

namespace Retro.Web.Models
{
    public class RetrospectiveItemCategoryModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public IList<RetrospectiveItemModel> Items { get; set; }
    }
}