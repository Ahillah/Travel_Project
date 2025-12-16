using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Flights
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA_Code { get; set; }

        // سيتم تعريف العلاقة في DbContext
        public virtual ICollection<Flight> DepartingFlights { get; set; }
        public virtual ICollection<Flight> ArrivingFlights { get; set; }
        public virtual ICollection<FlightOffer>? TargetedOffers { get; set; }
    }
}
