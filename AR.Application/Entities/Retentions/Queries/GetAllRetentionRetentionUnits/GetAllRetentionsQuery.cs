using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionUnits
{
    public class GetAllRetentionUnitsQuery : IRequest<RetentionUnitsListViewModel>
    {
        public Enums.UnitType UnitType { get; set; }
    }
}
