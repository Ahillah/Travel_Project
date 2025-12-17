using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Tour.TourInclusion
{
    public class TourInclusionDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string InclusionDetails { get; set; }
    }
}
