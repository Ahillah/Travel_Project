using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Tour.TourDate
{
    public class CreateTourDateDto
    {
        public int TourId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}
