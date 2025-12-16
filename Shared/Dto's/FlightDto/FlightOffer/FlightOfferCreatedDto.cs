using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.FlightOffer
{
    public class FlightOfferCreatedDto
    {
        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }

        public int? FlightId { get; set; }
        public int? AirlineId { get; set; }
        public int? ArrivalAirportId { get; set; }

    }
}
