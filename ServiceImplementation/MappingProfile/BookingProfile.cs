using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using Shared.Dto_s.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
   public class BookingProfile :Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.BookingType, opt => opt.MapFrom(src => src.BookingType))
               .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate));

            // CreateBookingDto → Model
            CreateMap<CreateBookingDto, Booking>()
                .ForMember(dest => dest.BookingType, opt => opt.MapFrom(src => src.BookingType))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending")) // الافتراضي عند الإنشاء
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => DateTime.UtcNow));

     
            // UpdateBookingDto → Model
            CreateMap<UpdateBookingDto, Booking>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
