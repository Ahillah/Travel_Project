using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Tours
{
    public class TourInclusion
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string InclusionDetails { get; set; } // مثال: All meals included

        [ForeignKey("TourId")]
        public virtual Tours Tour { get; set; }
    }
}
