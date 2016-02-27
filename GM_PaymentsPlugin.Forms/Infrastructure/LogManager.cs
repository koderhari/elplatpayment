using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.Forms.Infrastructure
{
    public class LogManager
    {
        private static ILogger _currentLogger;

        static LogManager()
        {
            _currentLogger = new LoggerNLog();
        }
        public static ILogger CurrentLogger { 
            get 
            {
                return _currentLogger;
            }
            set 
            {
                _currentLogger = value;
            }
        }
    }
}
