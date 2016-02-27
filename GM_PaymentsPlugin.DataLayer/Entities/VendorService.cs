using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.DataLayer.Entities
{
    public class VendorService
    {
        public VendorService()
        {
            Counters = new List<Counter>();
        }

        public string Id { get; set; }
        public string Number { get; set; }

        public string Name { get; set; }

        public string VendorId { get; set; }
        public string FormatInput { get; set; }
        
        public string AccountLabel { get; set; }
        public bool HasCounters 
        { 
            get 
            {
                if (Counters.Count > 0)
                    return true;
                else return false;
        
            } 
        }

        public List<Counter> Counters { get; set; }
    }
}
