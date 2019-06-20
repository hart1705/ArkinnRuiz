using AR.Application.Entities.Retentions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionApprovals
{
    public class RetentionApprovalsListViewModel
    {
        public IEnumerable<RetentionApprovalDto> RetentionApprovals { get; set; }
    }
}
