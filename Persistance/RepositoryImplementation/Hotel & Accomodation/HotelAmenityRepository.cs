using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Hotel___Accommodation
{
    public class HotelAmenityRepository : IHotelAmenityRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelAmenityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HotelAmenity>> GetByHotelAsync(int hotelId)
            => await _context.HotelAmenities
                .Where(ha => ha.HotelId == hotelId)
                .Include(ha => ha.Amenity)
                .AsNoTracking()
                .ToListAsync();


        public async Task<HotelAmenity> AddAsync(HotelAmenity entity)
        {
            _context.HotelAmenities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<HotelAmenity>> GetAllAsync()
        {
            return await _context.HotelAmenities
                .Include(h => h.Hotel)
                .Include(a => a.Amenity)
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int hotelId, int amenityId)
        {
            var hotelAmenity = await GetByIdAsync(hotelId, amenityId);
            if (hotelAmenity == null)
                return false;

            _context.HotelAmenities.Remove(hotelAmenity);
            return true;  // Save in service
        }

        public async Task<HotelAmenity> GetByIdAsync(int hotelId, int amenityId)
        {
            return await _context.HotelAmenities
                .FirstOrDefaultAsync(ha => ha.HotelId == hotelId && ha.AmenityId == amenityId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}

