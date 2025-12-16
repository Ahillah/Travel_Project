using DomainLayer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Booking_Transaction
{
    public class Transaction
    {
        public int Id { get; set; }
      
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        //  مهم جداً للربط مع Stripe
        public string PaymentIntentId { get; set; }

        //  ربط الـ Transaction بالـ Booking
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }

        //  ربط Transaction بالـ Payment (اللي فيه card details)
        public int PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public virtual Payment Payment { get; set; }
    }
}
