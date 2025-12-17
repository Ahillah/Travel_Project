using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Tours;
using Shared.Dto_s.Booking.TourBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile.Booking
{
    public class TourBookingProfile : Profile
    {
        public TourBookingProfile()
        {
            CreateMap<CreateTourBookingDto, TourBooking>();
            CreateMap<TourBooking, TourBookingDto>();

            CreateMap<TourBooking, BookingTourDto>()
                .ForMember(d => d.Tour, o => o.MapFrom(s => s.TourDate));

            CreateMap<TourDate, TourInfoDto>()
                .ForMember(d => d.TourId, o => o.MapFrom(s => s.Tour.Id))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Tour.Title));
        }
    }
}
