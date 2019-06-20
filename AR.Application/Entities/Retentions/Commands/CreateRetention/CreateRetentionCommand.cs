using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.CreateRetention
{
    public class CreateRetentionCommand : IRequest<string>
    {
        public string ClientName { get; set; }
        public string CustomerID { get; set; }
        public string ContactNumber { get; set; }
        public string CurrentProject { get; set; }
        public string CurrentUnitNumber { get; set; }
        public decimal Price { get; set; }
        public decimal GP { get; set; }
        public decimal GPValue { get; set; }
        public Boolean SIMAH { get; set; }
        public string TypeOfCounterOffers { get; set; }
        public string Description { get; set; }
        public string VAS { get; set; }
        public string RefNo { get; set; }
    }
}
