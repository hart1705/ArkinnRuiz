using AR.Application.Entities.Retentions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionCollectionUnitPlans
{
    public class RetentionCollectionUnitPlansListViewModel
    {
        public IEnumerable<RetentionCollectionUnitPlanDto> RetentionCollectionUnitPlans { get; set; }
    }
}
