using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.FlightDto.Airport
{
    public  class AirportCreatedDto
    {
        [Required(ErrorMessage = "Airport name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "IATA Code is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "IATA code must be 3 characters.")]
        public string IataCode { get; set; } 
    }
}
