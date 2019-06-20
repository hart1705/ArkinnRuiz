using AR.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Entities
{
    public class RetentionUnit : RecordInformation
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string UnitNo { get; set; }
        public decimal Price { get; set; }
        public decimal GP { get; set; }
        public decimal GPValue { get; set; }
        public Enums.UnitType UnitType { get; set; }
        public string RetentionId { get; set; }
        public Retention Retention { get; set; }
    }
}
