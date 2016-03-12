using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ElPlat_PaymentsPlugin.Forms.Helpers
{
    class FormatHelper
    {
        public static int GetLengthFromFormat(string format)
        {
            string pattern = "^x[(]([0-9]+)[)]";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            if (rgx.Match(format).Success)
            {
                int result = 0;
                if (Int32.TryParse(rgx.Match(format).Groups[1].Value, out result))
                    return result;
                else return 100;
            }
            else
            {
                return format.Length;
            }
        }

        public static string ParseCounterFormat(string format)
        {
            var result = new StringBuilder();
            if (format.Length==0) return "000000000";
            if (format.IndexOf(".") > 0)
            {
                var parts = format.Split('.');
                var count = parts[0].Replace(",", "").Length;
                while (count > 0)
                {
                    result.Append("0");
                    count--;
                }
                result.Append(".");
                count = parts[1].Replace(",", "").Length;
                while (count > 0)
                {
                    result.Append("0");
                    count--;
                }
            }
            else
            {
                var count=format.Replace(",","").Length;
                
                while(count>0)
                {
                    result.Append("0");
                    count--;
                }
                
            }
            return result.ToString();
        }
    }
}
