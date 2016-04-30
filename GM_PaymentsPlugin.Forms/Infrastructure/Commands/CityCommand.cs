using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
        protected static byte ZipFlag = (byte)33;
        
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

            if (CheckCompressedBytes(allBytes))
                allBytes = UnCompressBytes(allBytes);
            var result =Encoding.GetEncoding(866).GetString(allBytes.ToArray(), 0, allBytes.Count);
            CheckError(result);
            return result;
        }


        private bool CheckCompressedBytes(List<byte> allBytes)
        {
            if (allBytes.Count < 1) return false;
            if (allBytes[0] == ZipFlag) return true;
            return false;
        }

        private List<byte> UnCompressBytes(List<byte> allBytes)
        {
            byte[] data=new byte[allBytes.Count - 1];
            allBytes.CopyTo(1, data, 0, data.Length);
            return Decompress(data).ToList();

        }


        public byte[] UnZipStr(byte[] input)
        {
            using (MemoryStream inputStream = new MemoryStream(input))
            {
                using (DeflateStream gzip =
                  new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        gzip.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }
        

        static byte[] Decompress(byte[] data)
        {
           
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
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
