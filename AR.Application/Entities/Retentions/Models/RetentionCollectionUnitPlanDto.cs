using AR.Application.Interfaces.Mapping;
using AR.Domain.Entities;
using AR.Domain.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Models
{
    public class RetentionCollectionUnitPlanDto : IHaveCustomMapping
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

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<RetentionCollectionUnitPlan, RetentionCollectionUnitPlanDto>();
                //.ForMember(vDTO => vDTO.SoldDate, opt => opt.MapFrom(v => v.SoldDate))
                //.ForMember(vDTO => vDTO.ReservedDate, opt => opt.MapFrom(v => v.ReservedDate))
                //.ForMember(vDTO => vDTO.PaymentPlan, opt => opt.MapFrom(v => v.PaymentPlan))
                //.ForMember(vDTO => vDTO.FirstInstallment, opt => opt.MapFrom(v => v.FirstInstallment))
                //.ForMember(vDTO => vDTO.LastInstallment, opt => opt.MapFrom(v => v.LastInstallment))
                //.ForMember(vDTO => vDTO.NoSettledInstallments, opt => opt.MapFrom(v => v.NoSettledInstallments))
                //.ForMember(vDTO => vDTO.NoOfInstallments, opt => opt.MapFrom(v => v.NoOfInstallments))
                //.ForMember(vDTO => vDTO.CollectedAmount, opt => opt.MapFrom(v => v.CollectedAmount))
                //.ForMember(vDTO => vDTO.TotalCollectedAmount, opt => opt.MapFrom(v => v.TotalCollectedAmount))
                //.ForMember(vDTO => vDTO.CollectedPercent, opt => opt.MapFrom(v => v.CollectedPercent))
                //.ForMember(vDTO => vDTO.DueAmount, opt => opt.MapFrom(v => v.DueAmount))
                //.ForMember(vDTO => vDTO.RemainingAmount, opt => opt.MapFrom(v => v.RemainingAmount))
                //.ForMember(vDTO => vDTO.UnitType, opt => opt.MapFrom(v => v.UnitType))
                //.ForMember(vDTO => vDTO.RetentionId, opt => opt.MapFrom(v => v.RetentionId));
        }
    }
}
