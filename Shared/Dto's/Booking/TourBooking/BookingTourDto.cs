using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking.TourBooking
{
    public class BookingTourDto
    {
        public int BookingId { get; set; }
        public int NumberOfPeople { get; set; }
        public TourInfoDto Tour { get; set; }
    }
}
