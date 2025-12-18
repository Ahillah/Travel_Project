using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Flights
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IATA_Code { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<FlightOffer> FlightOffers { get; set; }
    }
}
