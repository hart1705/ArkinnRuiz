using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionWaiver
{
    public class DeleteRetentionWaiverCommand : IRequest
    {
        public string Id { get; set; }
    }
}
