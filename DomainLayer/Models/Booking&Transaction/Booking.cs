using DomainLayer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Booking_Transaction
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string BookingType { get; set; } // لتحديد نوع الحجز
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Confirmed, Cancelled, Pending

        [ForeignKey("UserId")]
        public virtual TouristUser User { get; set; }

        // علاقات One-to-One
        public virtual HotelBooking HotelBooking { get; set; }
        public virtual FlightBooking FlightBooking { get; set; }
        public virtual TourBooking TourBooking { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
