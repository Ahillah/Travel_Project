using AutoMapper;
using DomainLayer.Models.Flights;
using Shared.Dto_s.FlightDto.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class AirportProfile:Profile
    {
        public AirportProfile()
        {
            CreateMap<Airport, AirportDto>()
            .ForMember(dest => dest.IataCode, opt => opt.MapFrom(src => src.IATA_Code));
            CreateMap<Airport, AirportDetailsDto>()
            .ForMember(dest => dest.IataCode, opt => opt.MapFrom(src => src.IATA_Code))
            .ForMember(dest => dest.DepartingFlights, opt => opt.MapFrom(src => src.DepartingFlights))
            .ForMember(dest => dest.ArrivingFlights, opt => opt.MapFrom(src => src.ArrivingFlights))
            .ForMember(dest => dest.TargetedOffers, opt => opt.MapFrom(src => src.TargetedOffers));
            CreateMap<AirportCreatedDto, Airport>()
            .ForMember(dest => dest.IATA_Code, opt => opt.MapFrom(src => src.IataCode));
            CreateMap<AirportUpdatedDto, Airport>()
            .ForMember(dest => dest.IATA_Code, opt => opt.MapFrom(src => src.IataCode));
        }
    }
}
