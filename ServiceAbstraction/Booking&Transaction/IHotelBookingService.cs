using Shared.Dto_s.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Booking_Transaction
{
    public interface IHotelBookingService
    {
        Task<IEnumerable<HotelBookingDto>> GetBookingAllAsync();
        Task<HotelBookingDto> GetBookingByIdAsync(int bookingId);
        Task<HotelBookingDto> AddBookingAsync(HotelBookingDto dto);
        Task<bool> UpdateBookingAsync(int bookingId, HotelBookingDto dto);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<IEnumerable<HotelBookingDto>> GetBookingsByRoomAsync(int roomId);
    }
}
