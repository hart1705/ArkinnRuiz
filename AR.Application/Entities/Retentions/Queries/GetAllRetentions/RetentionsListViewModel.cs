using AR.Application.Entities.Retentions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentions
{
    public class RetentionsListViewModel
    {
        public IEnumerable<RetentionDto> Retentions { get; set; }
    }
}
