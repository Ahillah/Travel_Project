using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using Shared.Dto_s.Booking_TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class FlightBookingProfile:Profile
    {
        public FlightBookingProfile()
        {
            // Entity -> DTO
            CreateMap<FlightBooking, FlightBookingDto>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Booking.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Booking.UserId))
                .ForMember(dest => dest.BookingType, opt => opt.MapFrom(src => src.Booking.BookingType))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Booking.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Booking.Status))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.Booking.BookingDate))
                .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.FlightNumber))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.Flight.DepartureTime))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.Flight.ArrivalTime))
                .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.Flight.DepartureAirport.Name))
                .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.Flight.ArrivalAirport.Name));

            // DTO -> Entity (لـ Create)
            CreateMap<FlightBookingCreateDto, FlightBooking>();

            // DTO -> Entity (لـ Update)
            CreateMap<FlightBookingUpdateDto, FlightBooking>();
        }
    }
}
