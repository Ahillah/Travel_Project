using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
    public class ResetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string VerificationCode { get; set; } = default!;

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = default!;

   
    }

}
