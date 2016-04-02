using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.DataLayer.Entities
{
    public class AddInfo
    {
        public string Id { get; set; }
        
        public bool Required { get; set; }

        public string Name { get; set; }

        public string VendorServiceId { get; set; }

        public string Value { get; set; }
    }
}
