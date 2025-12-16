using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Tours
{
    public class TourItinerary
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int DayNumber { get; set; }
        public string DayTitle { get; set; }
        public string Activities { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }
    }
}
