using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Hotel___Accommodation
{
    public class PriceAndAvailabilityDto
    {
        public PriceAndAvailabilityDto() { }

        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int AvailableUnits { get; set; }

    }
}
