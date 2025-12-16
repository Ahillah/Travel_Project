using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceImplementation.MappingProfile.Hotel___Accommodation
{
    public class AmenityProfile : Profile
    {
        public AmenityProfile()
        {
            CreateMap<AmenityDto, Amenity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }


    }
}
