using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Hotels___Accommodation
{
    public class PricesAndAvailability
    {
        public int RoomId { get; set; }
        public DateTime Date { get; set; }

        public decimal Price { get; set; }
        public int AvailableUnits { get; set; }

        public virtual Room Room { get; set; }
    }
}
