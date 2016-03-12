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
    public class ViewModelBase : INotifyPropertyChanged
    {


        protected void SetValue<T>(string propertyName, ref T oldValue, ref T newValue)
        {
            oldValue = newValue;
            NotifyPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
