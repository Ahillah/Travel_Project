using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Booking_Transaction
{
    public interface IHotelBookingRepository
    {
        Task<IEnumerable<HotelBooking>> GetAllBookingAsync();
        Task<HotelBooking> GetBookingByIdAsync(int bookingId);
        Task<HotelBooking> AddBookingAsync(HotelBooking entity);
        Task<bool> UpdateBookingAsync(HotelBooking entity);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<IEnumerable<HotelBooking>> GetBookingsByRoomAsync(int roomId);
        Task<bool> SaveAsync();
    }
}
