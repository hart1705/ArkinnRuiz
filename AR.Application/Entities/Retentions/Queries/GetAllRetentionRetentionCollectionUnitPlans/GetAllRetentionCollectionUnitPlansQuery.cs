using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionCollectionUnitPlans
{
    public class GetAllRetentionCollectionUnitPlansQuery : IRequest<RetentionCollectionUnitPlansListViewModel>
    {
        public Enums.UnitType UnitType { get; set; }
    }
}
