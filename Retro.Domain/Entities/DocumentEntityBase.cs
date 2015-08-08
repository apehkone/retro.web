using System;
using Microsoft.Azure.Documents;

namespace Retro.Domain.Entities
{
    public class DocumentEntityBase : Document, IEntityBase
    {
        public DateTime? UpdatedOn {
            get {
                return GetPropertyValue<DateTime?>("updatedOn");
            }
            set {
                SetPropertyValue("updatedOn", value);
            }
        }

        public DateTime? CreatedOn {
            get {
                return GetPropertyValue<DateTime?>("createdOn");
            }
            set {
                SetPropertyValue("createdOn", value);
            }
        }
    }
}