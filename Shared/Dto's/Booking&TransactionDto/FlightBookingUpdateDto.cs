using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking_TransactionDto
{
    public class FlightBookingUpdateDto
    {
        public string Status { get; set; } // Confirmed, Cancelled, Pending
        public string SeatNumber { get; set; }
        public string FareClass { get; set; }
        public string PassengerDetails { get; set; }
    }
}
