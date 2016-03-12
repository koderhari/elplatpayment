using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.ViewModels
{
    class AccountInfoViewModel
    {
        [DisplayName("Лицевой счет")]
        public string PersonalNumber { get; set; }
        [DisplayName("Задолженность")]
        public decimal Amount { get; set; }
        [DisplayName("ФИО")]
        public string FullName { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [Browsable(false)]
        public string VendorServiceId { get; set; }

        [DisplayName("Услуга")]
        public string VendorServiceName { get; set; }

        [Browsable(false)]
        public string VendorId { get; set; }
    }
}
