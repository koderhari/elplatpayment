using ElPlat_PaymentsPlugin.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands
{



    class BarcodeCommand :CityCommand
    {
        public List<AccountInfo> AccountInfos { get; set; }

        User _user;
        string _barcode;

        public BarcodeCommand(string ip, int port, User user, string barcode)
            : base(ip, port)
        {
            _user = user;
            _barcode = barcode;
            AccountInfos = new List<AccountInfo>();
        }

        public override void Execute()
        {
            StringBuilder commandString = new StringBuilder();
            commandString.Append("barcode")
                .Append(delimiterL1).Append(_user.UserName)
                .Append(delimiterL1).Append(_barcode);

            
            Send(commandString.ToString());
            var data=Receive();
            if (Success)
            {
                ProccessData(data);
            }
        }

       
        void ProccessData(string data)
        {
            var accountInfoParts = data.Split(delimiterL1);

            if (accountInfoParts.Length == 2 && accountInfoParts[1].Trim('\0').Length == 0)
            {
                return;
            }

            for (var i = 1; i < accountInfoParts.Length; i++)
            {
                AccountInfos.Add(ProccessAccountInfoData(accountInfoParts[i]));
            }
        }

        private AccountInfo ProccessAccountInfoData(string paymentData)
        {
            
            var parts=paymentData.Split(delimiterL2);
            
            var itemResul = new AccountInfo();
            itemResul.VendorServiceId= parts[0];
            itemResul.PersonalNumber = parts[1];
            itemResul.FullName = parts[3];
            itemResul.Address= parts[4];
            itemResul.Amount = Decimal.Parse(parts[2]
                                                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                                                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                                                );

            return itemResul;
        }

    }
}


