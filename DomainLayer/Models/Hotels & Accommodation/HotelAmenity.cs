using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Hotels___Accommodation
{
    public class HotelAmenity
    {
        public int HotelId { get; set; }
        public int AmenityId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}
