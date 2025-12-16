using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Tours
{
    public class TourDestination
    {
        public int TourId { get; set; }
        public int DestinationId { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
