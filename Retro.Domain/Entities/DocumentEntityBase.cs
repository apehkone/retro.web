using System;
using Microsoft.Azure.Documents;

namespace Retro.Domain.Entities
{
    public class DocumentEntityBase : Document, IEntityBase
    {
        public DateTime? UpdatedOn {
            get {
                return GetValue<DateTime?>("updatedOn");
            }
            set {
                SetValue("updatedOn", value);
            }
        }

        public DateTime? CreatedOn {
            get {
                return GetValue<DateTime?>("createdOn");
            }
            set {
                SetValue("createdOn", value);
            }
        }
    }
}