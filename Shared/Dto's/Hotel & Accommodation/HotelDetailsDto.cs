using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Hotel___Accommodation
{
    public class HotelDetailsDto
    {
        public HotelDetailsDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Room> Rooms { get; set; }   // List of rooms in the hotel
        public IEnumerable<string> Amenities { get; set; } // List of amenity names
    }
}
