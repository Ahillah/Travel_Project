using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking.TourBooking
{
    public class CreateTourBookingDto
    {
        public int BookingId { get; set; }
        public int TourDateId { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
