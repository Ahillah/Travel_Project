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
    public class PriceAndAvailabilityRepository : IPriceAndAvailabilityRepository
    {
        private readonly ApplicationDbContext _context;

        public PriceAndAvailabilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PricesAndAvailability> AddAsync(PricesAndAvailability entity)
        {
            _context.PricesAndAvailability.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //public async Task<bool> DeleteAsync(int roomId, DateTime date)
        //{
        //    var entity = await GetByIdAsync(roomId, date);
        //    if (entity == null) return false;

        //    _context.PricesAndAvailability.Remove(entity);
        //    return await _context.SaveChangesAsync() > 0;
        //}
        public async Task<bool> DeleteAsync(int roomId, DateTime date)
        {
            var entity = await GetByIdAsync(roomId, date);
            if (entity == null) return false;

            _context.PricesAndAvailability.Remove(entity);
            return true; // only mark for delete
        }


        public async Task<IEnumerable<PricesAndAvailability>> GetAllAsync()
        {
            return await _context.PricesAndAvailability
                .Include(p => p.Room)
                .ToListAsync();
        }

        public async Task<PricesAndAvailability> GetByIdAsync(int roomId, DateTime date)
        {
            return await _context.PricesAndAvailability
                .FirstOrDefaultAsync(p => p.RoomId == roomId && p.Date == date);
        }

        public async Task<bool> Update(PricesAndAvailability item)
        {
            _context.PricesAndAvailability.Update(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PricesAndAvailability>> GetByRoom(int roomId)
        {
            return await _context.PricesAndAvailability
                .Include(p => p.Room)
                .Where(p => p.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PricesAndAvailability>> GetRoomAvailabilityAsync(int propertyId, DateTime start, DateTime end)
        {
            return await _context.PricesAndAvailability
                .Include(p => p.Room)
                .Where(p => p.Room.HotelId == propertyId)
                .Where(p => p.Date >= start && p.Date <= end)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
