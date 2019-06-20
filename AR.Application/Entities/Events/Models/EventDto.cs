using AR.Application.Interfaces.Mapping;
using AR.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Events.Models
{
    public class EventDto : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Event, EventDto>()
                .ForMember(vDTO => vDTO.Title, opt => opt.MapFrom(v => v.Title))
                .ForMember(vDTO => vDTO.Description, opt => opt.MapFrom(v => v.Description))
                .ForMember(vDTO => vDTO.Location, opt => opt.MapFrom(v => v.Location));
        }
    }
}
