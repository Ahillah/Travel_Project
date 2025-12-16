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

        public virtual Payment Payment { get; set; } = default!;
    }
}
