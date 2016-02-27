using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.DataLayer.Entities
{
    public class AccountInfo
    {

        public AccountInfo()
        {
            PaymentCounters = new List<PaymentCounter>();
        }

        public string PersonalNumber { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public List<PaymentCounter> PaymentCounters { get; set; }
    }
}
