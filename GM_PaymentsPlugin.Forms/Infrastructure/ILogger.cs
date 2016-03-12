using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure
{
    public interface ILogger
    {
        void Error(string message,Exception error);
        void Info(string message);
    }
}
