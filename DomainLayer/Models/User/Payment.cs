using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Identity
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookingId { get; set; }
        public string PaymentMethod { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CVC { get; set; }

        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("UserId")]
        public virtual TouristUser User { get; set; }
        public int TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; } = default!;
    }
}
