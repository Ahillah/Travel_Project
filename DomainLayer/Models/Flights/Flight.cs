using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Flights
{
    public class Flight
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public string FlightNumber { get; set; }
        public int DepartureAirportId { get; set; } // FK
        public int ArrivalAirportId { get; set; }   // FK
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }

        [ForeignKey("AirlineId")]
        public virtual Airline Airline { get; set; }

        // سيتم تعريف العلاقة في DbContext لتفادي التعارض
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport ArrivalAirport { get; set; }

        public virtual ICollection<FlightPrice> Prices { get; set; }
        public virtual ICollection<FlightBooking> FlightBookings { get; set; }
        public virtual ICollection<FlightOffer> FlightOffers { get; set; }
    }
}
