using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPlat_PaymentsPlugin.DataLayer.Entities
{

    public class Payment
    {


        public Payment()
        {
            ListPaymentCounters = new List<PaymentCounter>();
            ListAddInfos = new List<AddInfo>();
        }
        

        
        public String Id { 
            get
            {
                return TransactionId;
            } 
            set
            {
                TransactionId = value;
            } 
        }

        public string TransactionId { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountComission { get; set; }

        public string PersonalNumber { get; set; }

        public string ClientFullName { get; set; }

        public string ClientAddress { get; set; }

        public string PaymentTypeId { get; set; }

        public bool IsConfirmed { get; set; }

        public string VendorId { get; set; }
        
        public string VendorServiceId { get; set; }

        public string VendorServiceNumber { get; set; }

        public string INNOptional { get; set; }
        public string KPPOptional { get; set; }

        public List<PaymentCounter> ListPaymentCounters {get;set;}


        public List<AddInfo> ListAddInfos { get; set; }
    }
}
