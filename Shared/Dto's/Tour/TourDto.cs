using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Tour
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal BasePrice { get; set; }
        public int DurationInDays { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Destinations { get; set; }
    }
}
