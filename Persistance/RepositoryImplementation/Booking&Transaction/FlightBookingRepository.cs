using DomainLayer.Models.Booking_Transaction;
using DomainLayer.RepositoryInterface.Booking_Transaction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Booking_Transaction
{
    public class FlightBookingRepository : GenericRepository<FlightBooking,int>, IFlightBookingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FlightBookingRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        } 
         // هيرجع ال بوكينج لو كان فلايت 
        public async Task<FlightBooking?> GetByBookingIdAsync(int bookingId)
        {
             return await  dbContext.FlightBookings
                .Include(fb=>fb.Booking)
                .Include(fb=> fb.Flight)
                .FirstOrDefaultAsync(fb=> fb.BookingId == bookingId);
        }

        public async Task<IEnumerable<FlightBooking>> GetByFlightIdAsync(int flightId)
        {
            return await dbContext.FlightBookings.Where(fb=>fb.FlightId == flightId)
                .Include(fb => fb.Booking)
                      .Include(fb => fb.Flight).ToListAsync();
        }
    }
}
