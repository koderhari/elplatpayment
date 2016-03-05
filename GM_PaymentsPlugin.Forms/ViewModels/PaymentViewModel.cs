using GM_PaymentsPlugin.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GM_PaymentsPlugin.Forms.ViewModels
{

    public class PaymentViewModel:ViewModelBase
    {


        string _personalNumber;
        decimal _amount;
        string _clientFullName;
        string _clientAddress;

        public PaymentViewModel()
        {
            ListPaymentCounters = new List<PaymentCounterViewModel>();
        }

        public String Id { get; set; }


        public string Description { get; set; }


        
        
        
        public decimal Amount 
        { 
            get
            {
                return _amount;
            }
            set
            {
                if (value != _amount)
                {
                    SetValue("Amount", ref _amount , ref value);
                }
            }
        }

        public decimal AmountComission { get; set; }

        
        
        public string PersonalNumber 
        { 
            get
            {
                return _personalNumber;
            }
            set
            {
                if (value != _personalNumber)
                {
                    SetValue("PersonalNumber", ref _personalNumber,ref value );
                }
            }
        }

        public string ClientFullName 
        {
            get
            {
                return _clientFullName;
            }
            set 
            {
                if (value != _clientFullName)
                {
                    SetValue("ClientFullName", ref _clientFullName, ref value);
                }

            }
        }

        public string ClientAddress 
        { 
            get
            {
                return _clientAddress;
            }
            set 
            {
                if (value != _clientAddress)
                {
                    SetValue("ClientAddress", ref _clientAddress, ref value);
                }

            }
        }

        public string PaymentTypeId { get; set; }

        public bool IsConfirmed { get; set; }

        public string VendorId { get; set; }

        public string VendorServiceId { get; set; }

        public string TransactionId { get; set; }
      
        public List<PaymentCounterViewModel> ListPaymentCounters { get; set; }
    }
}
