using DomainLayer.Models.Hotels___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile.Hotel___Accommodation
{
    public class HotelDetailsProfile : AutoMapper.Profile
    {
        public HotelDetailsProfile()
        {
            CreateMap<Hotel, HotelDetailsDto>()
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.HotelAmenities.Select(ha => ha.Amenity.Name)));
        }
    }
}
