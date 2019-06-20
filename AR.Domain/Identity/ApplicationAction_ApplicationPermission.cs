using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static AR.Domain.Helpers.Enums;

namespace AR.Domain.Identity
{
    public class ApplicationAction_ApplicationPermission
    {
        public string Id { get; set; }
        public string ApplicationPermissionId { get; set; }
        [ForeignKey("ApplicationPermissionId")]
        public ApplicationPermission ApplicationPermission { get; set; }
        public string ApplicationActionId { get; set; }
        [ForeignKey("ApplicationActionId")]
        public ApplicationAction ApplicationAction { get; set; }
        public AccessType AccessType { get; set; }
    }
}
