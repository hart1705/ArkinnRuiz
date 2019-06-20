using AR.Domain.Entities;
using AR.Domain.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string ContactId { get; set; }
        public Contact Contact { get; set; }
        public Enums.Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public void SetOnCreate(string userId = null)
        {
            this.CreatedOn = DateTime.UtcNow;
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedBy = userId;
            this.ModifiedBy = userId;
            this.Status = Enums.Status.Active;
        }

        public void SetOnModified(string userId = null)
        {
            this.ModifiedOn = DateTime.UtcNow;
            this.ModifiedBy = userId;
        }
    }
}
