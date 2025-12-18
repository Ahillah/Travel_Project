using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Tour.TourItinerary
{
    public class CreateTourItineraryDto
    {
        public int DayNumber { get; set; }
        public string DayTitle { get; set; }
        public string Activities { get; set; }
    }
}
