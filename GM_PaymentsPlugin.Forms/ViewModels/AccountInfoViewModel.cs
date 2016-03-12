using ElPlat_PaymentsPlugin.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.ViewModels
{
    class AccountInfoViewModel
    {
        [DisplayName("Лиц. счет")]
        [StringLength(120, MinimumLength = 3)]
        public string PersonalNumber { get; set; }
        [DisplayName("Сумма")]
        [StringLength(15, MinimumLength = 3)]
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
        public VendorService VendorService { get; set; }
    }
}
