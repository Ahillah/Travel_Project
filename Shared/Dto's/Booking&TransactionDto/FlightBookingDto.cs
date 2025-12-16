using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking_TransactionDto
{
    public class FlightBookingDto
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public string BookingType { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Confirmed, Cancelled, Pending
        public DateTime BookingDate { get; set; }

        
        public int FlightId { get; set; }
        public string PassengerDetails { get; set; }
        public string SeatNumber { get; set; }
        public string FareClass { get; set; }

        
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
    }
}
