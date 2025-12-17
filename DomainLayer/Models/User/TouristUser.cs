using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Identity
{
    public class TouristUser: ApplicationUser
    {
        public string IDNumber { get; set; } = default!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
