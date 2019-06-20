using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Entities
{
    public class Retention : RecordInformation
    {
        public Retention()
        {
            RetentionApproval = new HashSet<RetentionApproval>();
            RetentionCollectionUnitPlan = new HashSet<RetentionCollectionUnitPlan>();
            RetentionUnit = new HashSet<RetentionUnit>();
            RetentionWaiver = new HashSet<RetentionWaiver>();
        }
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string CustomerID { get; set; }
        public string ContactNumber { get; set; }
        public string CurrentProject { get; set; }
        public string CurrentUnitNumber { get; set; }
        public decimal Price { get; set; }
        public decimal GP { get; set; }
        public decimal GPValue { get; set; }
        public bool SIMAH { get; set; }
        public string TypeOfCounterOffers { get; set; }
        public string Description { get; set; }
        public string VAS { get; set; }
        public string RefNo { get; set; }
        public ICollection<RetentionApproval> RetentionApproval { get; private set; }
        public ICollection<RetentionCollectionUnitPlan> RetentionCollectionUnitPlan { get; private set; }
        public ICollection<RetentionUnit> RetentionUnit { get; private set; }
        public ICollection<RetentionWaiver> RetentionWaiver { get; private set; }
    }
}
