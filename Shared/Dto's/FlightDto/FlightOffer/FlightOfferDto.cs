using Shared.Dto_s.FlightDto.Airport;
using Shared.Dto_s.FlightDto.flight;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.FlightOffer
{
    public class FlightOfferDto
    {
        public int Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal Price { get; set; }
        public string FlightNumber { get; set; }

        public string AirlineName { get; set; }




        public string ArrivalAirportName { get; set; }
    }
}
