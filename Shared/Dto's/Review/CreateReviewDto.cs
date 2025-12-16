
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Review
{

    public class CreateReviewDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int TargetId { get; set; }

        [Required]
        [RegularExpression("Hotel|Tour|Flight", ErrorMessage = "Invalid TargetType")]
        public string TargetType { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }
    }

}