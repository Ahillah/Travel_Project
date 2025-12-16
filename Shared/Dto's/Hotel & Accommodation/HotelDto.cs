using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Hotel___Accommodation
{
    public class HotelDto
    {
        public HotelDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ImageUrel { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? StarRating { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }

    }

    }

