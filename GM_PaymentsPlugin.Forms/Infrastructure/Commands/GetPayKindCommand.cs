using ElPlat_PaymentsPlugin.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands
{
    class GetPayKindCommand:CityCommand
    {
        public List<Vendor> Vendors { get; set; }
        public List<VendorService> VendorServices { get; set; }
        public string PostIndex { get; set; }


        User _user;

        public GetPayKindCommand(string ip, int port, User user)
            : base(ip, port)
        {
            _user = user;
            VendorServices = new List<VendorService>();
            Vendors = new List<Vendor>();
        }

        public override void Execute()
        {
            StringBuilder commandString = new StringBuilder();
            commandString.Append("getpaykind")
                .Append(delimiterL1).Append(_user.UserName)
                .Append(delimiterL1).Append(_user.Password);
            
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
            PostIndex = parts[1];
            for (var i = 2; i < parts.Length; i++)
            {
                var serviceParts = parts[i].Split(delimiterL2);
                var currentVendor = PrepareVendor(serviceParts);
                PrepareVendorService(serviceParts, currentVendor);
            }
        }


        Vendor PrepareVendor(string[] parts)
        {
            var vendorId = parts[1];
            
            var currentVendor = Vendors.FirstOrDefault(x => x.VendorId == vendorId);
            if (currentVendor == null)
            {
                currentVendor = new Vendor();
                currentVendor.Number = parts[0];
                currentVendor.VendorId = parts[1];
                currentVendor.Name = parts[3];
                Vendors.Add(currentVendor);
            }
            return currentVendor;
        }

        VendorService PrepareVendorService(string[] parts,Vendor vendor)
        {
            var currentVendorService = new VendorService();
            currentVendorService.VendorId = vendor.VendorId;
            currentVendorService.Id = parts[2];
            currentVendorService.Number = parts[4];
            currentVendorService.Name = parts[5];
            currentVendorService.AccountLabel = parts[6];
            currentVendorService.FormatInput = parts[7];
            VendorServices.Add(currentVendorService);
            for (var i = 8; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("#СЧ")) 
                {
                    var counterParts = parts[i].Split(delimiterL3);
                    currentVendorService.Counters.Add(PrepareCounter(counterParts, currentVendorService.Id));
                }
                
            }

            return currentVendorService;
        }


        Counter PrepareCounter(string[] parts,string vendorServiceId)
        {
            var counter = new Counter();
            counter.FullName = parts[1];
            counter.Name = parts[3];
            counter.InputFormat= parts[2];
            counter.Id= parts[3];
            counter.UnitMeasure= parts[4];
            counter.IsRequired = parts[5]=="no"?false:true;
            counter.VendorServiceId = vendorServiceId;

            return counter;
        }


    }
}

