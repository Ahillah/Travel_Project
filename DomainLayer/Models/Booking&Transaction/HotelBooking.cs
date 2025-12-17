using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Booking_Transaction
{
    public class HotelBooking
    {
        [Key]
        public int BookingId { get; set; } // PK & FK لـ Booking
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }

        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
    }
}
