using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Booking_Transaction
{
    public class TourBooking
    {
        [Key]
        public int BookingId { get; set; } // PK & FK لـ Booking
        public int TourDateId { get; set; }
        public int NumberOfPeople { get; set; }

        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        [ForeignKey("TourDateId")]
        public virtual TourDate TourDate { get; set; }
    }
}
