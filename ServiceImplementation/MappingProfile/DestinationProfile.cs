using AutoMapper;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<Destination, DestinationDto>();
            CreateMap<CreateDestinationDto, Destination>();
            CreateMap<UpdateDestinationDto, Destination>();
        }
    }
}
