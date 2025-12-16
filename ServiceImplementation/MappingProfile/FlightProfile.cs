using AutoMapper;
using DomainLayer.Models.Flights;
using Shared.Dto_s.FlightDto.Airport;
using Shared.Dto_s.FlightDto.flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class FlightProfile:Profile
    {
        public FlightProfile()
        {
            
            CreateMap<DomainLayer.Models.Flights.Flight, Flight_Dto>();
              
            CreateMap<DomainLayer.Models.Flights.Flight, FlightDetailsDto>()
                .ForMember(dest => dest.AirlineName,
                           opt => opt.MapFrom(src => src.Airline.Name))
                .ForMember(dest => dest.DepartureAirportName,
                           opt => opt.MapFrom(src => src.DepartureAirport.Name))
                .ForMember(dest => dest.ArrivalAirportName,
                           opt => opt.MapFrom(src => src.ArrivalAirport.Name))
                .ForMember(dest => dest.Prices,
                           opt => opt.MapFrom(src => src.Prices))
                .ForMember(dest => dest.AvailableSeats,
                           opt => opt.Ignore());


            CreateMap<FlightCreatedDto, DomainLayer.Models.Flights.Flight>()
                .ForMember(dest => dest.Duration, opt => opt.Ignore());

    
            CreateMap<FlightUpdatedDto, DomainLayer.Models.Flights.Flight>()
                .ForMember(dest => dest.Duration, opt => opt.Ignore());
        }
    }
}
