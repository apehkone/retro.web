using System;
using System.Collections.Generic;

namespace Retro.Web.Models
{
    public class RetrospectiveModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string SelectedTemplate { get; set; }
        public IList<RetrospectiveItemCategoryModel> Categories { get; set; }
    }
}