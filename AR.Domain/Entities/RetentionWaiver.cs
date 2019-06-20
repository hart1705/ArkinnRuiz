using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Entities
{
    public class RetentionWaiver : RecordInformation
    {
        public string Id { get; set; }
        public decimal InstallementAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public decimal BearingCost { get; set; }
        public string RetentionId { get; set; }
        public Retention Retention { get; set; }

    }
}
