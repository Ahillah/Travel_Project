using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Booking_Transaction
{
    public interface IFlightBookingRepository: IGenericRepository<FlightBooking, int>
    {
        Task<FlightBooking?> GetByBookingIdAsync(int bookingId);
        Task<IEnumerable<FlightBooking>> GetByFlightIdAsync(int flightId);
    }
}
