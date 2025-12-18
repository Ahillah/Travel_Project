using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Identity
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TargetId { get; set; } // PK  للكيان المقيَّم في حالتنا هيكةن الفندق او الرحلة لة ليها تقييم
        public string TargetType { get; set; } // مثال: "Hotel" أو "Tour"
        public int Rating { get; set; } // (1-5)
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public virtual TouristUser User { get; set; }
    }
}
