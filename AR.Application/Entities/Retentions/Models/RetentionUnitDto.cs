using AR.Application.Interfaces.Mapping;
using AR.Domain.Entities;
using AR.Domain.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Models
{
    public class RetentionUnitDto : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string UnitNo { get; set; }
        public decimal Price { get; set; }
        public decimal GP { get; set; }
        public decimal GPValue { get; set; }
        public Enums.UnitType UnitType { get; set; }
        public string RetentionId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<RetentionUnit, RetentionUnitDto>()
                .ForMember(vDTO => vDTO.Project, opt => opt.MapFrom(v => v.Project))
                .ForMember(vDTO => vDTO.UnitNo, opt => opt.MapFrom(v => v.UnitNo))
                .ForMember(vDTO => vDTO.Price, opt => opt.MapFrom(v => v.Price))
                .ForMember(vDTO => vDTO.GP, opt => opt.MapFrom(v => v.GP))
                .ForMember(vDTO => vDTO.GPValue, opt => opt.MapFrom(v => v.GPValue))
                .ForMember(vDTO => vDTO.Price, opt => opt.MapFrom(v => v.Price))
                .ForMember(vDTO => vDTO.GP, opt => opt.MapFrom(v => v.GP))
                .ForMember(vDTO => vDTO.GPValue, opt => opt.MapFrom(v => v.GPValue))
                .ForMember(vDTO => vDTO.UnitType, opt => opt.MapFrom(v => v.UnitType))
                .ForMember(vDTO => vDTO.RetentionId, opt => opt.MapFrom(v => v.RetentionId));
        }
    }
}
