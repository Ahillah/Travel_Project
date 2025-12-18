using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Flights
{
    public class FlightOffer
    {
        public int Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal Price { get; set; }
     
        public int? FlightId { get; set; }
        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }

     
        public int? AirlineId { get; set; }
        [ForeignKey("AirlineId")]
        public virtual Airline Airline { get; set; }
        public int? ArrivalAirportId { get; set; }
        
        public virtual Airport? ArrivalAirport { get; set; }
    }
}
