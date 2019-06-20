using AR.Application.Interfaces.Mapping;
using AR.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Models
{
    public class RetentionWaiverDto : IHaveCustomMapping
    {
        public string Id { get; set; }
        public decimal InstallementAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public decimal BearingCost { get; set; }
        public string RetentionId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<RetentionWaiver, RetentionWaiverDto>()
                .ForMember(vDTO => vDTO.InstallementAmount, opt => opt.MapFrom(v => v.InstallementAmount))
                .ForMember(vDTO => vDTO.ServiceChargeAmount, opt => opt.MapFrom(v => v.ServiceChargeAmount))
                .ForMember(vDTO => vDTO.BearingCost, opt => opt.MapFrom(v => v.BearingCost))
                .ForMember(vDTO => vDTO.RetentionId, opt => opt.MapFrom(v => v.RetentionId));
        }
    }
}
