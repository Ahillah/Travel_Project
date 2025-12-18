using AutoMapper;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.TourDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class TourDestinationProfile : Profile
    {
        public TourDestinationProfile()
        {
            CreateMap<TourDestination, TourDestinationDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour.Title))
                .ForMember(dest => dest.DestinationName, opt => opt.MapFrom(src => src.Destination.Name));

            CreateMap<AddTourDestinationDto, TourDestination>();
        }
    }
}
