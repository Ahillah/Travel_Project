using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Tour.TourDestination
{
    public class TourDestinationDto
    {
        public int TourId { get; set; }
        public int DestinationId { get; set; }
        public string TourName { get; set; }
        public string DestinationName { get; set; }
    }
}
