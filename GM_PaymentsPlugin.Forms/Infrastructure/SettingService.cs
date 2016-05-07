using NLog.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure
{
    public class SettingService
    {
        string fileName = "";
        string _serverIp;
        int _port;
        static int _workingPort; 
        public static int WorkingPort 
        {
            get
            {
               
                return _workingPort;
            }

            set 
            {
                _workingPort = value;
            }
        }


        public SettingService(string filename)
        {
            this.fileName = filename;
        }

        public SettingService()
        {
            this.fileName = AppDomain.CurrentDomain.BaseDirectory + "\\settings.xml";
        }


        public string GetServerIP()
        {
            if (_serverIp == null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                _serverIp = xmlDoc.GetElementsByTagName("server").Item(0).InnerText;
                xmlDoc = null;
            }
            return _serverIp;
        }

        public int GetPort()
        {
            if (_port == 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                _port = Int32.Parse(xmlDoc.GetElementsByTagName("port").Item(0).InnerText);
                xmlDoc = null;
            }
            return _port;
        }
    }
}
