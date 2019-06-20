using AR.Application.Interfaces.Mapping;
using AR.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Models
{
    public class RetentionDto : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string CustomerID { get; set; }
        public string ContactNumber { get; set; }
        public string CurrentProject { get; set; }
        public string CurrentUnitNumber { get; set; }
        public decimal Price { get; set; }
        public decimal GP { get; set; }
        public decimal GPValue { get; set; }
        public Boolean SIMAH { get; set; }
        public string TypeOfCounterOffers { get; set; }
        public string Description { get; set; }
        public string VAS { get; set; }
        public string RefNo { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Retention, RetentionDto>()
                .ForMember(vDTO => vDTO.ClientName, opt => opt.MapFrom(v => v.ClientName))
                .ForMember(vDTO => vDTO.CustomerID, opt => opt.MapFrom(v => v.CustomerID))
                .ForMember(vDTO => vDTO.ContactNumber, opt => opt.MapFrom(v => v.ContactNumber))
                .ForMember(vDTO => vDTO.CurrentProject, opt => opt.MapFrom(v => v.CurrentProject))
                .ForMember(vDTO => vDTO.CurrentUnitNumber, opt => opt.MapFrom(v => v.CurrentUnitNumber))
                .ForMember(vDTO => vDTO.Price, opt => opt.MapFrom(v => v.Price))
                .ForMember(vDTO => vDTO.GP, opt => opt.MapFrom(v => v.GP))
                .ForMember(vDTO => vDTO.GPValue, opt => opt.MapFrom(v => v.GPValue))
                .ForMember(vDTO => vDTO.SIMAH, opt => opt.MapFrom(v => v.SIMAH))
                .ForMember(vDTO => vDTO.TypeOfCounterOffers, opt => opt.MapFrom(v => v.TypeOfCounterOffers))
                .ForMember(vDTO => vDTO.Description, opt => opt.MapFrom(v => v.Description))
                .ForMember(vDTO => vDTO.VAS, opt => opt.MapFrom(v => v.VAS))
                .ForMember(vDTO => vDTO.RefNo, opt => opt.MapFrom(v => v.RefNo));
        }
    }
}
