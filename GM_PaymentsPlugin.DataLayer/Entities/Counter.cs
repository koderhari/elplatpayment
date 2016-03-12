using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.DataLayer.Entities
{
    public class Counter
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public string VendorServiceId {get;set;}

        public string Name { get; set; }

        public string FullName { get; set; }

        public bool IsRequired { get; set; }
        
        public string InputFormat { get; set; }
        
        public string UnitMeasure{ get; set; }
    }
}
