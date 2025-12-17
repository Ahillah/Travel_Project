using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking.TourBooking
{
    public class TourInfoDto
    {
        public int TourId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
    }
}
