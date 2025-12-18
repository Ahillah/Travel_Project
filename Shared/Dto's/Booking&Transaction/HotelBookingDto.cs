using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking_Transaction
{
    public class HotelBookingDto
    {
        public HotelBookingDto() { }
        public int BookingId { get; set; } // PK & FK لـ Booking
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Name { get; set; }
        public int NumberOfGuests { get; set; }

    }
}
