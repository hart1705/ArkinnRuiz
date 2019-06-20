using AR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Identity
{
    public class ApplicationPermission : RecordInformation
    {
        public string Id { get; set; }
        public string ApplicationPermission_Id { get; set; }
        public string Description { get; set; }

        public ICollection<ApplicationAction_ApplicationPermission> ApplicationAction_ApplicationPermissions { get; set; }
        public ICollection<ApplicationRole_ApplicationPermission> ApplicationRole_ApplicationPermissions { get; set; }
    }
}
