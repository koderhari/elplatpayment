using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands
{
    abstract class CityCommand:IDisposable
    {
        protected Socket server;
        protected static char delimiterL1= Convert.ToChar(2);
        protected static char delimiterL2=Convert.ToChar(1);
        protected static char delimiterL3 = Convert.ToChar(3);
        protected static string counterHeader = "#СЧ";
        protected static string addInfoHeader = "#ДС";
        
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }


        public CityCommand(string ip,int port)
        {
            IPEndPoint ipep =
                      new IPEndPoint(IPAddress.Parse("1.1.254.12"), 41007);
            server = new Socket(AddressFamily.InterNetwork,
                              SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ipep);
        }

        public abstract void Execute();
        
        
        protected void Send(string data)
        {
            var bytesForSend = Encoding.GetEncoding(866).GetBytes(data);
            var sendbytes = server.Send(bytesForSend);
        }

        protected void CheckError(string data)
        {
            var parts=data.Split(delimiterL1);
            if (parts[0] == "FALSE")
            {
                Success = false;
                ErrorMessage = parts[1];
            }
            else Success = true;
        }

        protected string Receive()
        {
            List<byte> allBytes = new List<byte>();
            byte[] bytes = null;
            bool flag = true;
            while (flag)
            {
                bytes = new byte[1000];
                try
                {
                    int bytesRec = server.Receive(bytes);
                    if (bytesRec == 0) break;
                    allBytes.AddRange(bytes);
                }
                catch
                {
                    flag = false;
                }

            }
            var result =Encoding.GetEncoding(866).GetString(allBytes.ToArray(), 0, allBytes.Count);
            CheckError(result);
            return result;
        }



        public void Dispose()
        {
            if (server != null)
            {
                server.Close();
                server.Dispose();
                server = null;
            }
        }
    }
}
