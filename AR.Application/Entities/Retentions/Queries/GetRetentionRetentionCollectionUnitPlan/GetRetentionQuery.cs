﻿using AR.Application.Entities.Retentions.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetRetentionCollectionUnitPlan
{
    public class GetRetentionCollectionUnitPlanQuery : IRequest<RetentionCollectionUnitPlanDto>
    {
        public string Id { get; set; }
    }
}
