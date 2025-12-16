using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Booking_Transaction;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Hotel___Accommodation
{
    public class HotelBookingRepository : IHotelBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HotelBooking>> GetAllBookingAsync()
        {
            return await _context.HotelBookings
                .Include(b => b.Room)
                .Include(b => b.Booking)
                .ToListAsync();
        }

        public async Task<HotelBooking> GetBookingByIdAsync(int bookingId)
        {
            return await _context.HotelBookings
                .Include(b => b.Room)
                .Include(b => b.Booking)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task<HotelBooking> AddBookingAsync(HotelBooking entity)
        {
            _context.HotelBookings.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateBookingAsync(HotelBooking entity)
        {
            _context.HotelBookings.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            var entity = await GetBookingByIdAsync(bookingId);
            if (entity == null) return false;

            _context.HotelBookings.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<HotelBooking>> GetBookingsByRoomAsync(int roomId)
        {
            return await _context.HotelBookings
                .Where(b => b.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
