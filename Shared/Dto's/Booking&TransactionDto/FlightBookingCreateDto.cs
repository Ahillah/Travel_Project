using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking_TransactionDto
{
    public class FlightBookingCreateDto
    {
        public int FlightId { get; set; }
        public string UserId { get; set; }
        public string PassengerDetails { get; set; }
        public string SeatNumber { get; set; }
        public string FareClass { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingType { get; set; } = "Flight";
    }
}
