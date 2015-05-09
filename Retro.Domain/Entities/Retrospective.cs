using System.Collections.Generic;

namespace Retro.Domain.Entities
{
    public class Retrospective : DocumentEntityBase
    {
        public string Description { get { return GetValue<string>("description"); } set { SetValue("description", value); } }

        public IList<RetrospectiveItemCategory> Categories { get { return GetValue<IList<RetrospectiveItemCategory>>("categories"); } set { SetValue("categories", value); } }
    }
}