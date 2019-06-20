using AR.Application.Entities.Retentions.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetRetentionApproval
{
    public class GetRetentionApprovalQuery : IRequest<RetentionApprovalDto>
    {
        public string Id { get; set; }
    }
}
