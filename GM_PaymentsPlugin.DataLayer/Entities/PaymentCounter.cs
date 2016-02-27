using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace GM_PaymentsPlugin.DataLayer.Entities
{
    public class PaymentCounter
    {
        public string CounterId { get; set; }
        public int Order { get; set; }
        public string PaymentId { get; set; }

        public string Name { get; set; }

        public decimal NewValue { get; set; }

        public decimal OldValue { get; set; }

        public bool IsRequired { get; set; }

    }
}
