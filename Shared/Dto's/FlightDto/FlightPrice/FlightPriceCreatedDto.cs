using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.FlightPrice
{
    public class FlightPriceCreatedDto
    {
        [Required]
        public int FlightId { get; set; } 

        [Required]
        public string Class { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [Required]
        public string BaggageAllowance { get; set; }
    }
}
