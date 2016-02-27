using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.DataLayer.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PostUserName { get; set; }
        public string WorkPlace { get; set; }
        
        public string PostIndex { get; set; }
    }
}
