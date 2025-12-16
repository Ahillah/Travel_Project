using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Hotel___Accomodation
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> AddAsync(Hotel entity)
        {
             _context.Hotels.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hotel = await GetByIdAsync(id);
            if (hotel == null)
            {
                return false;
            }

            _context.Hotels.Remove(hotel);
            var rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _context.Hotels
            .Include(h => h.Rooms)
            .Include(h => h.HotelAmenities)
            .ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels
            .Include(h => h.Rooms)
            .Include(h => h.HotelAmenities)
                .ThenInclude(ha => ha.Amenity)
            .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<bool> UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.Entry(hotel).Property(x => x.Id).IsModified = false;

            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city)
        {
            return await _context.Hotels
                .Where(h => h.City.ToLower() == city.ToLower())
                .Include(h => h.Rooms)
                .Include(h => h.HotelAmenities)
                .ToListAsync();
        }
        public async Task<IEnumerable<Hotel>> SearchHotelsAsync(string location, DateTime checkIn, DateTime checkOut, int guests)
        {
            return await _context.Hotels.Where(h => h.City.Contains(location))
                .Where(h => h.Rooms.Any (r => r.Capacity >= guests))
                .ToListAsync();

        }
        public async Task<Hotel> GetPropertyDetailsAsync(int propertyId)
        {
            return await _context.Hotels
                .Include(h => h.Rooms)
                .Include(h => h.HotelAmenities).ThenInclude(ha => ha.Amenity)
                .FirstOrDefaultAsync(h => h.Id == propertyId);
        }
        public async Task<IEnumerable<Hotel>> GetSimilarPropertiesAsync(int propertyId)
        {
            var hotel = await _context.Hotels.FindAsync(propertyId);

            return await _context.Hotels
                .Where(h => h.City == hotel.City && h.Id != propertyId)
                .Take(5)
                .ToListAsync();
        }

    }
}
