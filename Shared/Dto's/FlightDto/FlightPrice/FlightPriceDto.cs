using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.FlightPrice
{
    public class FlightPriceDto
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }
        public string BaggageAllowance { get; set; }
    }
}
