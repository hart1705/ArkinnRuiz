using AR.Application.Entities.Retentions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionUnits
{
    public class RetentionUnitsListViewModel
    {
        public IEnumerable<RetentionUnitDto> RetentionUnits { get; set; }
    }
}
