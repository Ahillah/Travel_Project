using AutoMapper;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class TourProfile : Profile
    {
        public TourProfile()
        {
            CreateMap<Tours, TourDto>()
                .ForMember(dest => dest.Destinations,
                           opt => opt.MapFrom(src => src.TourDestinations.Select(d => d.Destination)));

            CreateMap<CreateTourDto, Tours>();
            CreateMap<UpdateTourDto, Tours>();
        }
    }
}
