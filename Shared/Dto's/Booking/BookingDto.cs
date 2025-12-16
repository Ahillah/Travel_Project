using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Booking
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string BookingType { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime BookingDate { get; set; }
    }

}
