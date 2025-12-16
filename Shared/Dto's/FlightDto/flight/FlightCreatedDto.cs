using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.flight
{
    public class FlightCreatedDto
    {
        [Required]
        public int AirlineId { get; set; } // FK

        [Required]
        [StringLength(50)]
        public string FlightNumber { get; set; }

        [Required]
        public int DepartureAirportId { get; set; } // FK

        [Required]
        public int ArrivalAirportId { get; set; } // FK

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

  

        [Required]
        [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500.")]
        public int TotalCapacity { get; set; }
    }
}
