
using Shared.Dto_s.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IBookingService
    {
        Task<BookingDto> CreateAsync(string userId, CreateBookingDto dto);
        Task<BookingDto> GetByIdAsync(int id);
        Task<IReadOnlyList<BookingDto>> GetUserBookingsAsync(string userId);
        Task<BookingDto> UpdateAsync(int bookingId, string userId, UpdateBookingDto dto);
        Task<bool> CancelAsync(int bookingId, string userId);
    }
}
