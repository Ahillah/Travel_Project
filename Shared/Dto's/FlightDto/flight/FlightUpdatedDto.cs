using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.flight
{
    public class FlightUpdatedDto
    {
        [Required]
        public int AirlineId { get; set; }

        [Required]
        [StringLength(50)]
        public string FlightNumber { get; set; }

        [Required]
        public int DepartureAirportId { get; set; }

        [Required]
        public int ArrivalAirportId { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }


        [Required]
        [Range(1, 500)]
        public int TotalCapacity { get; set; }
    }
}
