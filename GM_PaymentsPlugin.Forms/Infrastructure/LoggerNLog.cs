using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.Forms.Infrastructure
{
    class LoggerNLog:ILogger
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void Error(string message, Exception error)
        {
            logger.Error(message + " " + error.StackTrace);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }
    }
}
