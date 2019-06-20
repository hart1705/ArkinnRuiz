using AR.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.CreateRetentionWaiver
{
    public class CreateRetentionWaiverCommand : IRequest<string>
    {
        public decimal InstallementAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public decimal BearingCost { get; set; }
        public string RetentionId { get; set; }
    }
}
