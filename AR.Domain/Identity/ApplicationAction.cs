using AR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Identity
{
    public class ApplicationAction : RecordInformation
    {
        public string Id { get; set; }
        public string ApplicationAction_Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public bool IsHttpPOST { get; set; }
        public bool? AccessNeeded { get; set; }
        public ICollection<ApplicationAction_ApplicationPermission> ApplicationAction_ApplicationPermissions { get; set; }
    }
}
