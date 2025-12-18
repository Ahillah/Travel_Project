using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Flights
{
    public class FlightPrice
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string Class { get; set; } // مثال: Economy, Business
        public decimal Price { get; set; }
        public string BaggageAllowance { get; set; }

        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }
    }
}
