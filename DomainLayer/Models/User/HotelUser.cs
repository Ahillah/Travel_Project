using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Identity
{
    public class HotelUser:ApplicationUser
    {
        public int HotelId { get; set; } = default!;
        public virtual Hotel Hotel { get; set; } = default!;
    }
}
