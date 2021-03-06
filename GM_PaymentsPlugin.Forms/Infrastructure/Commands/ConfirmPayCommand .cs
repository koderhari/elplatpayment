﻿using ElPlat_PaymentsPlugin.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands
{



    class ConfirmPay :CityCommand
    {
        public List<PayCommandResult> ConfirmPayCommandResults { get; set; }

        User _user;
        private List<Payment> _payments;

        public ConfirmPay(string ip, int port, User user, List<Payment> payments)
            : base(ip, port)
        {
            _user = user;
            _payments = payments;
            ConfirmPayCommandResults = new List<PayCommandResult>();
        }

        public override void Execute()
        {
            StringBuilder commandString = new StringBuilder();
            commandString.Append("confirm")
                .Append(delimiterL1).Append(_user.UserName);

            foreach(var payment in _payments)
            {
                commandString.Append(delimiterL1).Append(payment.TransactionId);
            }
            
            Send(commandString.ToString());
            var data=Receive();
            if (Success)
            {
                ProccessData(data);
            }
        }


        void ProccessData(string data)
        {
            var paymentParts = data.Split(delimiterL1);

            for (var i = 1; i < paymentParts.Length; i++)
            {
                ConfirmPayCommandResults.Add(ProccessPaymentData(paymentParts[i]));
            }
        }

        private PayCommandResult ProccessPaymentData(string paymentData)
        {
            
            var parts=paymentData.Split(delimiterL2);
            
            var itemResul = new PayCommandResult();
            itemResul.TransactionId= parts[0];
            itemResul.ErrorCode= parts[1];
            itemResul.ErrorMessage= parts[2];

            return itemResul;
        }

    }
}

