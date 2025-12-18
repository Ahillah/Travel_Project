using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Tour.TourDate
{
    public class UpdateTourDateDto
    {
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}
