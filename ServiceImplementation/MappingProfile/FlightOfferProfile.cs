using AutoMapper;
using DomainLayer.Models.Flights;
using Shared.Dto_s.FlightDto.FlightOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class FlightOfferProfile:Profile
    {
        public FlightOfferProfile()
        {
            
            CreateMap<FlightOffer, FlightOfferDto>()
                .ForMember(dest => dest.AirlineName,
                           opt => opt.MapFrom(src => src.Airline.Name))  
                .ForMember(dest => dest.FlightNumber,
                           opt => opt.MapFrom(src => src.Flight.FlightNumber))
                .ForMember(dest => dest.ArrivalAirportName,
                           opt => opt.MapFrom(src => src.ArrivalAirport.Name)); // سيستخدم Mapper من Airport إلى AirportDto

            // 2. تحويل FlightOfferCreatedDto إلى FlightOffer (للإنشاء)
            CreateMap<FlightOfferCreatedDto, FlightOffer>();

            // 3. تحويل FlightOfferUpdatedDto إلى FlightOffer (للتحديث)
            CreateMap<FlightOfferUpdatedDto, FlightOffer>();

            // ...
        }
    }
}
