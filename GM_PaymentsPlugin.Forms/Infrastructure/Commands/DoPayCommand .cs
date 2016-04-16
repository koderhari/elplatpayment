using ElPlat_PaymentsPlugin.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands
{

    public class PayCommandResult
    {
        public string TransactionId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public bool Success 
        {
            get 
            {
                if (ErrorCode=="0") return true;
                return false;
            }
        }
    }

    class DoPayCommand :CityCommand
    {
        public List<PayCommandResult> DoPayCommandResults { get; set; }

        User _user;
        private List<Payment> _payments;

        public DoPayCommand(string ip, int port, User user,List<Payment> payments)
            : base(ip, port)
        {
            _user = user;
            _payments = payments;
            DoPayCommandResults = new List<PayCommandResult>();
        }

        public override void Execute()
        {
            StringBuilder commandString = new StringBuilder();
            commandString.Append("dopay")
                .Append(delimiterL1).Append(_user.UserName);

            foreach(var payment in _payments)
            {
                commandString.Append(delimiterL1).Append(PreparePaymentData(payment));
            }
            
            Send(commandString.ToString());
            var data=Receive();
            if (Success)
            {
                ProccessData(data);
            }
        }

        private string PreparePaymentData(Payment payment)
        {
            StringBuilder paymentData = new StringBuilder();
            paymentData
            .Append(payment.VendorServiceId).Append(delimiterL2)
            .Append(payment.PersonalNumber).Append(delimiterL2)
            .Append(payment.TransactionId).Append(delimiterL2)
            .Append(payment.Amount.ToString().Replace(',','.'));
            foreach(var counter in payment.ListPaymentCounters)
                paymentData.Append(delimiterL2).Append(PreparePaymentCounterData(counter));

            foreach (var addInfo in payment.ListAddInfos)
                paymentData.Append(delimiterL2).Append(PrepareAddInfoData(addInfo));


            //can optimize via return char[]
            return paymentData.ToString();
        }

        private string PrepareAddInfoData(AddInfo addInfo)
        {
            StringBuilder addInfoData = new StringBuilder();
            addInfoData.Append(counterHeader)
                        .Append(delimiterL3).Append(addInfo.Id)
                        .Append(delimiterL3).Append(addInfo.Value);

            //can optimize via return char[]
            return addInfoData.ToString();
        }

        private string PreparePaymentCounterData(PaymentCounter counter)
        {
            StringBuilder counterData = new StringBuilder();
            counterData.Append(counterHeader)
                        .Append(delimiterL3).Append(counter.CounterId)
                        .Append(delimiterL3).Append(counter.NewValue);

            //can optimize via return char[]
            return counterData.ToString();
        }

        void ProccessData(string data)
        {
            var paymentParts = data.Split(delimiterL1);

            for (var i = 1; i < paymentParts.Length; i++)
            {
                DoPayCommandResults.Add(ProccessPaymentData(paymentParts[i]));
            }
        }

        private PayCommandResult ProccessPaymentData(string paymentData)
        {
            
            var parts=paymentData.Split(delimiterL2);
            
            var itemResul = new PayCommandResult();
            itemResul.TransactionId= parts[2];
            itemResul.ErrorCode= parts[3];
            itemResul.ErrorMessage= parts[4];

            return itemResul;
        }

    }
}

