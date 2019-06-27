using AccommodationService;
using AgentApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentApp
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccommodationDTO, Accommodation>().ReverseMap();
                //.ForMember(dest => dest.AccommodationType, opt => opt.MapFrom(src => src.AccommodationType)).ReverseMap()
                //.ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location)).ReverseMap()
                //.ForMember(dest => dest.PeriodPrice, opt => opt.MapFrom(src => src.PeriodPrices)).ReverseMap();
        }
    }
}
