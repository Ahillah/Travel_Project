using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking
{
    public class CreateBookingDto
    {
        public string BookingType { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
