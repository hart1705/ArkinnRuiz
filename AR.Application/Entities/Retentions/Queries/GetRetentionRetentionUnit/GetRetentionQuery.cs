using AR.Application.Entities.Retentions.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetRetentionUnit
{
    public class GetRetentionUnitQuery : IRequest<RetentionUnitDto>
    {
        public string Id { get; set; }
    }
}
