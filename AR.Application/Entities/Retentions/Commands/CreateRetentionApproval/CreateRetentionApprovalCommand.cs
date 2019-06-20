using AR.Domain.Entities;
using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.CreateRetentionApproval
{
    public class CreateRetentionApprovalCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Signiture { get; set; }
        public Enums.ApprovalType ApprovalType { get; set; }
        public string RetentionId { get; set; }
    }
}
