using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Hotels___Accommodation
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<HotelBooking> HotelBookings { get; set; }
        public virtual ICollection<PricesAndAvailability> PricesAndAvailability { get; set; }
    }
}
