using AR.Domain.Entities;
using AR.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionCollectionUnitPlan
{
    public class UpdateRetentionCollectionUnitPlanCommand : IRequest<string>
    {
        public string Id { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime? ReservedDate { get; set; }
        public string PaymentPlan { get; set; }
        public DateTime? FirstInstallment { get; set; }
        public DateTime? LastInstallment { get; set; }
        public int NoSettledInstallments { get; set; }
        public int NoOfInstallments { get; set; }
        public decimal CollectedAmount { get; set; }
        public decimal TotalCollectedAmount { get; set; }
        public decimal CollectedPercent { get; set; }
        public decimal DueAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public Enums.UnitType UnitType { get; set; }
        public string RetentionId { get; set; }
    }
}
