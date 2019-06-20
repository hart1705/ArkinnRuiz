using AR.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Entities
{
    public abstract class RecordInformation
    {
        public virtual Enums.Status Status { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }

        public virtual void SetOnCreate(string userId = null)
        {
            this.CreatedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedBy = userId;
            this.ModifiedBy = userId;
            this.Status = Enums.Status.Active;
        }

        public virtual void SetOnModified(string userId = null)
        {
            this.ModifiedOn = DateTime.UtcNow;
            this.ModifiedBy = userId;
        }
    }
}
