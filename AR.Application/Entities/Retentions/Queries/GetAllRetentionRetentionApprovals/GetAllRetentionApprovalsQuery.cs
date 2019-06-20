using AR.Application.Entities.Retentions.Models;
using AR.Application.Helpers;
using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionApprovals
{
    public class GetAllRetentionApprovalsQuery : IRequest<RetentionApprovalsListViewModel>
    {
        public Enums.ApprovalType ApprovalType { get; set; }
        //public int draw { get; set; }
        //public int start { get; set; }
        //public int length { get; set; }
        //public List<Column> columns { get; set; }
        //public Search search { get; set; }
        //public List<Order> order { get; set; }
    }
}
