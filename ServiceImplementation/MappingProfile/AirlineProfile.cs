using AutoMapper;
using DomainLayer.Models.Flights;
using Shared.Dto_s.FlightDto.Airline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class AirlineProfile: Profile 
    {
        public AirlineProfile() {

            CreateMap<Airline, AirlineDto>().ReverseMap();

            CreateMap<AirlineCreateDto, Airline>();

          
            CreateMap<AirlineUpdateDto, Airline>();
            
        }
    }
}
