using AR.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionWaiver
{
    public class UpdateRetentionWaiverCommand : IRequest<string>
    {
        public string Id { get; set; }
        public decimal InstallementAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public decimal BearingCost { get; set; }
        public string RetentionId { get; set; }
    }
}
