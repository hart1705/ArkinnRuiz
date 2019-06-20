using AR.Application.Entities.Retentions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionWaivers
{
    public class RetentionWaiversListViewModel
    {
        public IEnumerable<RetentionWaiverDto> RetentionWaivers { get; set; }
    }
}
