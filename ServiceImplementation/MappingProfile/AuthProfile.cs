using AutoMapper;
using DomainLayer.Models.Identity;
using DomainLayer.Models.User;
using Shared.Dto_s.Review;
using Shared.Dtos.Identity;

namespace Shared
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // Tourist
            CreateMap<TouristRegisterDto, TouristUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Hotel Admin
            CreateMap<HotelRegisterDto, HotelUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AdminEmail))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AdminEmail));


        }
    }
}


