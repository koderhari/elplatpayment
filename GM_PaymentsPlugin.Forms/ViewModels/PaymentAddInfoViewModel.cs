using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ElPlat_PaymentsPlugin.Forms.ViewModels
{
    public class PaymentAddInfoViewModel : ViewModelBase
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public string PaymentId { get; set; }

        public string Name { get; set; }

        public string _value;
        public decimal _newValueStr;

        public string Value { 
            get
            {
                return _value; 
            }
            set 
            {
                if (value != _value)
                {
                    SetValue("Value", ref _value, ref value);
                }
            }
        }


        public bool Required { get; set; }


      

    }
}
