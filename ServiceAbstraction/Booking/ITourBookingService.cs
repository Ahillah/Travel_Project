using Shared.Dto_s.Booking.TourBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Booking
{
    public interface ITourBookingService
    {
        Task<TourBookingDto> CreateAsync(CreateTourBookingDto dto);
        Task<TourBookingDto?> GetByBookingIdAsync(int bookingId);
        Task<BookingTourDto?> GetBookingTourByIdAsync(int bookingId);
        Task<bool> UpdateAsync(int bookingId, UpdateTourBookingDto dto);
        Task<bool> DeleteAsync(int bookingId);
    }
}
