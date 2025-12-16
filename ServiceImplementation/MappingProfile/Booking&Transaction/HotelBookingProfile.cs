using DomainLayer.Models.Booking_Transaction;
using Shared.Dto_s.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile.Booking_Transaction
{
    public class HotelBookingProfile : AutoMapper.Profile
    {
        public HotelBookingProfile()
        {
            CreateMap<HotelBooking, HotelBookingDto>().ReverseMap();
        }
    }
}
