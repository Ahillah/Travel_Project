using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Tours
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public int DurationInDays { get; set; }
        public decimal BasePrice { get; set; }
        public string DifficultyLevel { get; set; }
        public int MinGroupSize { get; set; }
        public int MaxGroupSize { get; set; }

        public virtual ICollection<TourDate> AvailableDates { get; set; }
        public virtual ICollection<TourItinerary> Itineraries { get; set; }
        public virtual ICollection<TourInclusion> Inclusions { get; set; }
        public virtual ICollection<TourDestination> TourDestinations { get; set; }
    }
}
