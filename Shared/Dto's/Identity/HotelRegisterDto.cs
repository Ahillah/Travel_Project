using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
    public class HotelRegisterDto
    {
        public int HotelId { get; set; }
        [Required]
        public string HotelName { get; set; } = default!;

        [Required]
        public string FullHotelAddress { get; set; } = default!;

        [Required]
        public string ResponsiblePersonName { get; set; } = default!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = default!;

        [Required]
        public string Country { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string AdminEmail { get; set; } = default!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = default!;

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = default!;
    }

}
