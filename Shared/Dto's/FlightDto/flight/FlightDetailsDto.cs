using Shared.Dto_s.FlightDto.FlightPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.flight
{
    public class FlightDetailsDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public string AirlineName { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }

        public int TotalCapacity { get; set; }

        public int AvailableSeats { get; set; }

 
        public ICollection<FlightPriceDto>? Prices { get; set; }
    }
}
