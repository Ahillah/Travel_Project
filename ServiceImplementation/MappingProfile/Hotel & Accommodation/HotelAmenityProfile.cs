using DomainLayer.Models.Hotels___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile.Hotel___Accommodation
{
    public class HotelAmenityProfile : AutoMapper.Profile
    {
        public HotelAmenityProfile()
        {
            CreateMap<HotelAmenity, HotelAmenityDto>().ReverseMap();
        }
    }
}
