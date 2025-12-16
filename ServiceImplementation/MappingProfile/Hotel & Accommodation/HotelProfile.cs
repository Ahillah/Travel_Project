using DomainLayer.Models.Hotels___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile.Hotel___Accommodation
{
    public class HotelProfile : AutoMapper.Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>();

            CreateMap<HotelDto, Hotel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
        }
    }

}
