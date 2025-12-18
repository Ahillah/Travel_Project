using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Payment
{
    public class ConfirmPaymentDto
    {
        public int BookingId { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
