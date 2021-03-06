﻿using AR.Domain.Entities;
using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionUnit
{
    public class UpdateRetentionUnitCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string UnitNo { get; set; }
        public decimal Price { get; set; }
        public decimal GP { get; set; }
        public decimal GPValue { get; set; }
        public Enums.UnitType UnitType { get; set; }
        public string RetentionId { get; set; }
    }
}
