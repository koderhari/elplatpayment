using GM_PaymentsPlugin.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GM_PaymentsPlugin.Forms.Infrastructure.Commands
{

    public class CheckPayCommandParams
    {
        public string VendorId { get; set; }
        public string VendorServiceId { get; set; }
        public string Account { get; set; }
    }
    
    class CheckPayCommand:CityCommand
    {
        public AccountInfo AccountInfo { get; set; }


        User _user;
        private CheckPayCommandParams _param;

        public CheckPayCommand(string ip, int port, User user,CheckPayCommandParams param)
            : base(ip, port)
        {
            _user = user;
            _param = param;
            AccountInfo = new AccountInfo() { PersonalNumber = param.Account};
        }

        public override void Execute()
        {
            StringBuilder commandString = new StringBuilder();
            commandString.Append("checkpay")
                .Append(delimiterL1).Append(_user.UserName)
                //.Append(delimiterL1).Append(_param.VendorId)
                .Append(delimiterL1).Append(_param.VendorServiceId)
                .Append(delimiterL1).Append(_param.Account);
            
            Send(commandString.ToString());
            var data=Receive();
            if (Success)
            {
                ProccessData(data);
            }
        }

        void ProccessData(string data)
        {
            var parts = data.Split(delimiterL1);
            AccountInfo.TransactionId = parts[1];
            AccountInfo.Amount = Decimal.Parse(parts[2]
                                                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                                                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                                                );
            AccountInfo.FullName = parts[3];
            AccountInfo.Address = parts[4];

            for (var i = 5; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("#СЧ"))
                {
                    var counterParts = parts[i].Split(delimiterL2);
                    AccountInfo.PaymentCounters.Add(PrepareCounter(counterParts));
                }
            }
        }







        PaymentCounter PrepareCounter(string[] parts)
        {
            var counter = new PaymentCounter();
            counter.CounterId= parts[1];
            counter.OldValue = Decimal.Parse(parts[2]
                                                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                                                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                                                ); 
            return counter;
        }


    }
}

