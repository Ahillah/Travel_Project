using DomainLayer.Models.Hotels___Accommodation;
using Microsoft.EntityFrameworkCore;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Hotel___Accommodation
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly ApplicationDbContext _context;
        public AmenityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> AddAsync(Amenity amenity)
        {
             _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var amenity = await GetByIdAsync(id);
            if (amenity != null)
            {
                _context.Amenities.Remove(amenity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<IEnumerable<Amenity>> GetAllAsync()
        {
            return await _context.Amenities
            .Include(a => a.HotelAmenities)
            .ToListAsync();
        }

        public async Task<Amenity> GetByIdAsync(int Id)
        {
            return await _context.Amenities
                        .Include(a => a.HotelAmenities)
                        .FirstOrDefaultAsync(a => a.Id == Id);
        }

        //public async Task<bool> UpdateAsync(Amenity amenity)
        //{
        //    _context.Amenities.Update(amenity);
        //    return await _context.SaveChangesAsync() > 0;
        //}
        public async Task<bool> UpdateAsync(Amenity amenity)
        {
            _context.Amenities.Update(amenity);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}

