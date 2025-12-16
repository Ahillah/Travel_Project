using Shared.Dto_s.FlightDto.flight;

using Shared.Dto_s.FlightDto.FlightOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.Airport
{
    public class AirportDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IataCode { get; set; }

        
      
        public ICollection<Flight_Dto>? DepartingFlights { get; set; }

        
        public ICollection<Flight_Dto>? ArrivingFlights { get; set; }

        public ICollection<FlightOfferDto>? TargetedOffers { get; set; }
    }
}
