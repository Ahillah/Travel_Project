using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile.Hotel___Accommodation
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Amenity, AmenityDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<HotelAmenity, HotelAmenityDto>().ReverseMap();
            CreateMap<PricesAndAvailability, PriceAndAvailabilityDto>().ReverseMap();
        }
    }

}
