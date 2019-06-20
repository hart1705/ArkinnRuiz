using AR.Application.Interfaces.Mapping;
using AR.Domain.Entities;
using AR.Domain.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Models
{
    public class RetentionApprovalDto : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Signiture { get; set; }
        public Enums.ApprovalType ApprovalType { get; set; }
        public string RetentionId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<RetentionApproval, RetentionApprovalDto>();
                //.ForMember(vDTO => vDTO.Name, opt => opt.MapFrom(v => v.Name))
                //.ForMember(vDTO => vDTO.Position, opt => opt.MapFrom(v => v.Position))
                //.ForMember(vDTO => vDTO.Signiture, opt => opt.MapFrom(v => v.Signiture))
                //.ForMember(vDTO => vDTO.ApprovalType, opt => opt.MapFrom(v => v.ApprovalType))
                //.ForMember(vDTO => vDTO.RetentionId, opt => opt.MapFrom(v => v.RetentionId));
        }
    }
}
