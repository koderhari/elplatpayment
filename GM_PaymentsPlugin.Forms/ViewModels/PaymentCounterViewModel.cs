using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GM_PaymentsPlugin.Forms.ViewModels
{
    public class PaymentCounterViewModel : ViewModelBase
    {
        public string CounterId { get; set; }
        public int Order { get; set; }
        public string PaymentId { get; set; }

        public string Name { get; set; }


        public string Format { get; set; }

        public decimal _newValue;
        public decimal _newValueStr;

        public decimal NewValue { 
            get
            { 
                return _newValue; 
            }
            set 
            {
                if (value != _newValue)
                {
                    SetValue("NewValue", ref _newValue,ref value);
                }
            }
        }

        public string NewValueStr
        {
            get
            {
                 //_newValue.ToString();
                return _newValue.ToString(Format);
            }
            set
            {

                var newval = Decimal.Parse(value);
                if (newval != _newValue)
                {

                    SetValue("NewValue", ref _newValue, ref newval);
                    //SetValue("NewValueStr", ref _newValue, ref value);
                }
            }
        }


        public decimal _oldValue;
        public decimal OldValue { get
        {
            return _oldValue;
        }
            set 
            {
                if (value != _oldValue)
                {
                    SetValue("OldValue", ref _oldValue, ref value);
                }
            }
        }

        public bool IsRequired { get; set; }


      

    }
}
