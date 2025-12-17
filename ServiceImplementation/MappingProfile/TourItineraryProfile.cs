using AutoMapper;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.TourItinerary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class TourItineraryProfile : Profile
    {
        public TourItineraryProfile()
        {
            CreateMap<TourItinerary, TourItineraryDto>();
            CreateMap<CreateTourItineraryDto, TourItinerary>();
            CreateMap<UpdateTourItineraryDto, TourItinerary>();
        }
    }
}
