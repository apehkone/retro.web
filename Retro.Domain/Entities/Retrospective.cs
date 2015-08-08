using System.Collections.Generic;

namespace Retro.Domain.Entities
{
    public class Retrospective : DocumentEntityBase
    {
        public string Description { get { return GetPropertyValue<string>("description"); } set { SetPropertyValue("description", value); } }

        public IList<RetrospectiveItemCategory> Categories { get { return GetPropertyValue<IList<RetrospectiveItemCategory>>("categories"); } set { SetPropertyValue("categories", value); } }
    }
}