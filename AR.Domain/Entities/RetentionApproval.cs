using AR.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Entities
{
    public class RetentionApproval : RecordInformation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Signiture { get; set; }
        public Enums.ApprovalType ApprovalType { get; set; }
        public string RetentionId { get; set; }
        public Retention Retention { get; set; }
    }
}
