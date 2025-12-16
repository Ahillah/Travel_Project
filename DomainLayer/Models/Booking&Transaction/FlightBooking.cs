using DomainLayer.Models.Flights;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Booking_Transaction
{
    public class FlightBooking
    {
        [Key]
        public int BookingId { get; set; } // PK & FK لـ Booking
        public int FlightId { get; set; }
        public string PassengerDetails { get; set; }
        public string SeatNumber { get; set; }
        public string FareClass { get; set; }

        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }
    }
}
