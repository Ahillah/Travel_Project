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
    //public class RoomRepository : IRoomRepository
    //{
    //    private readonly ApplicationDbContext _context;
    //    public RoomRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Room> AddAsync(Room room)
    //    {
    //       await _context.Rooms.AddAsync(room);
    //        _context.SaveChangesAsync();
    //        return room;
    //    }

    //    public async Task<bool> DeleteAsync(int id)
    //    {
    //        var room = await GetByIdAsync(id);
    //        if (room == null)
    //        {
    //            return false;

    //        }
    //        _context.Rooms.Remove(room);
    //        return await _context.SaveChangesAsync() > 0;
    //    }

    //    public async Task<IEnumerable<Room>> GetAllAsync()
    //    {
    //        return await _context.Rooms
    //         .Include(r => r.Hotel)
    //         .Include(r => r.PricesAndAvailability)
    //         .Include(r => r.HotelBookings)
    //         .ToListAsync();

    //    }

    //    public async Task<IEnumerable<Room>> GetAllByHotelAsync(int hotelId)
    //    => await _context.Rooms.Where(r => r.HotelId == hotelId).AsNoTracking().ToListAsync();

    //    public async Task<Room> GetByIdAsync(int Id)
    //    {
    //        return await _context.Rooms
    //        .Include(r => r.Hotel)
    //        .Include(r => r.PricesAndAvailability)
    //        .Include(r => r.HotelBookings)
    //        .FirstOrDefaultAsync(r => r.Id == Id);
    //    }

    //    public async Task<bool> SaveChangesAsync()
    //    {
    //        return await _context.SaveChangesAsync() > 0;
    //    }

    //    public async Task<bool>  UpdateAsync(Room room)
    //    {
    //        _context.Rooms.Update(room);
    //       return await _context.SaveChangesAsync() > 0 ;
    //    }


    //}
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room> AddAsync(Room room)
        {
            _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var room = await GetByIdAsync(id);
        //    if (room == null) return false;

        //    _context.Rooms.Remove(room);
        //    return await _context.SaveChangesAsync() > 0;
        //}
        public async Task<bool> DeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
                return false;

            _context.Rooms.Remove(room);

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.PricesAndAvailability)
                .Include(r => r.HotelBookings)
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllByHotelAsync(int hotelId)
        {
            return await _context.Rooms
                .Where(r => r.HotelId == hotelId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int Id)
        {
            return await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.PricesAndAvailability)
                .Include(r => r.HotelBookings)
                .FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task<bool> UpdateAsync(Room room)
        //{
        //    _context.Rooms.Update(room);
        //    return await _context.SaveChangesAsync() > 0;
        //}
        public async Task<bool> UpdateAsync(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }


    }

}
