using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Hotels___Accommodation
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<HotelAmenity> HotelAmenities { get; set; }
    }
}
