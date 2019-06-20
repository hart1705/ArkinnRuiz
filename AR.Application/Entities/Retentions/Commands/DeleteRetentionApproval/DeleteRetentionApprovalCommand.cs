using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionApproval
{
    public class DeleteRetentionApprovalCommand : IRequest
    {
        public string Id { get; set; }
    }
}
