using Shared.Dto_s.Booking_TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Booking_Transaction
{
    public interface IFlightBookingService
    {
        Task<FlightBookingDto?> GetByBookingIdAsync(int bookingId);
        Task<IEnumerable<FlightBookingDto>> GetByFlightIdAsync(int flightId);
        Task<FlightBookingDto> CreateFlightBookingAsync(FlightBookingCreateDto dto);
        Task<FlightBookingDto?> UpdateFlightBookingAsync(int bookingId, FlightBookingUpdateDto dto);
        Task<bool> DeleteFlightBookingAsync(int bookingId);
    }
}
