using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.Forms.ViewModels
{
    public class PaymentCartItemViewModel
    {
        [Browsable(false)]
        public string Id { get; set; }

        [DisplayName("Плательщик")]
        public string ClientFullName { get; set; }
        [DisplayName("Поставщик")]
        public string VendorName { get; set; }
        [DisplayName("Сумма")]
        public decimal Amount { get; set; }
    }
}
