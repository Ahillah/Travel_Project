using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Tours
{
    public class TourDate
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }

        public virtual ICollection<TourBooking> TourBookings { get; set; }
    
}
}
