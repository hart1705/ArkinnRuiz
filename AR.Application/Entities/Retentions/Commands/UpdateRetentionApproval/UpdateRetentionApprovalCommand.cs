using AR.Domain.Entities;
using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionApproval
{
    public class UpdateRetentionApprovalCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Signiture { get; set; }
        public Enums.ApprovalType ApprovalType { get; set; }
        public string RetentionId { get; set; }
    }
}
