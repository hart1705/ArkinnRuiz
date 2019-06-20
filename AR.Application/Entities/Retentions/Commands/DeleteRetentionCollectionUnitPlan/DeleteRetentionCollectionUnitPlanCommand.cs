using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionCollectionUnitPlan
{
    public class DeleteRetentionCollectionUnitPlanCommand : IRequest
    {
        public string Id { get; set; }
    }
}
