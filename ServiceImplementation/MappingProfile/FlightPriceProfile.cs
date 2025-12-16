using AutoMapper;
using DomainLayer.Models.Flights;
using Shared.Dto_s.FlightDto.FlightPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class FlightPriceProfile:Profile
    {
        public FlightPriceProfile()
        {
            CreateMap<FlightPrice, FlightPriceDto>();
             


            CreateMap<FlightPriceCreatedDto, FlightPrice>();

          
            CreateMap<FlightPriceUpdatedDto, FlightPrice>();
        }
       
    }
}
