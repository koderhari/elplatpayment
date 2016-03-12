using ElPlat_PaymentsPlugin.DataLayer.Entities;
using ElPlat_PaymentsPlugin.Forms.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure
{
    
    public class CheckPayException:Exception
    {
        public CheckPayException(string message)
            : base(message)
        { }
    }



    public class DoPayException : Exception
    {
        public DoPayException(string message)
            : base(message)
        { }
    }



    public class ConfirmPayException : Exception
    {
        public ConfirmPayException(string message)
            : base(message)
        { }
    }

        public class CancelPayException : Exception
    {
            public CancelPayException(string message)
            : base(message)
        { }
    }



        public class CommandException : Exception
        {
            public CommandException(string message)
                : base(message)
            { }
        }



    
    public class PaymentService
    {

        private static Dictionary<string, object> _cache = new Dictionary<string, object>();

        const string CACHE_VENDORS = "VENDROS_0";
        const string CACHE_VENDORSERVICES = "VENDROSSERVICES_0";
        const string CACHE_PAYMENTS = "PAYMENTS_0";

        private User _currentUser;
        private SettingService _settingService;


        public PaymentService(User currentUser,SettingService settingService)
        {
            _currentUser = currentUser;
            _settingService = settingService;
        }
        
        #region Utils
        private static T GetCacheKey<T>(string cacheKey, Func<T> cacheFunc=null) 
        {
            if (!_cache.ContainsKey(cacheKey) || _cache[cacheKey] == null)
            {
                if (cacheFunc != null)
                    _cache[cacheKey] = cacheFunc();
                else return default(T);
            }
            return (T)_cache[cacheKey];
        }
        #endregion

        public static void InitData(List<Vendor> vendors,List<VendorService> vendorServices)
        {
            GetCacheKey<List<Vendor>>(CACHE_VENDORS, () =>
            {
                return vendors;
            });
            GetCacheKey<List<VendorService>>(CACHE_VENDORSERVICES, () =>
            {
                return vendorServices;
            });

        }

        #region Vendors
        public List<Vendor> GetVendors()
        {
            var cachekey = CACHE_VENDORS;

            var result = GetCacheKey<List<Vendor>>(cachekey);
            
            //    () =>
            //{
            //    var vendors = new List<Vendor>();
            //    vendors.Add(new Vendor { Name = "Поставщик 1", Number = "1001", VendorId = "1" });
            //    vendors.Add(new Vendor { Name = "Поставщик 2", Number = "900", VendorId = "2" });
            //    vendors.Add(new Vendor { Name = "Поставщик 3", Number = "5837", VendorId = "3" });
            //    return vendors;
            //});



            return result;
        }


        public Vendor GetVendorById(string id)
        {
            return GetVendors().FirstOrDefault(x => x.VendorId == id);
        }


        public List<VendorService> GetVendorServices()
        {
            var cachekey = CACHE_VENDORSERVICES;
            var allServices = GetCacheKey<List<VendorService>>(cachekey);
            //    , () =>
            //{
            //    var vendorServices = new List<VendorService>();
            //    var vendorService = new VendorService { Id = "1", Number = "3", Name = "Услуга 1", VendorId = "1"};
            //    vendorServices.Add(vendorService);

            //    vendorServices.Add(new VendorService { Id = "2", Number = "200", Name = "Услуга 2", VendorId = "1" });
            //    vendorServices.Add(new VendorService { Id = "3", Number = "300", Name = "Услуга 3", VendorId = "2" });
            //    vendorServices.Add(new VendorService { Id = "4", Number = "700", Name = "Услуга 4", VendorId = "2" });
            //    vendorServices.Add(new VendorService { Id = "5", Number = "800", Name = "Услуга 5", VendorId = "3" });
            //    vendorServices.Add(new VendorService { Id = "6", Number = "900", Name = "Услуга 6", VendorId = "3" });

            //    vendorService.Counters.Add(new Counter { Id = "1", Name = "газ", Order = 1, VendorServiceId = "1",IsRequired=true });
            //    vendorService.Counters.Add(new Counter { Id = "2", Name = "свет", Order = 2, VendorServiceId = "1" });
            //    vendorService.Counters.Add(new Counter { Id = "3", Name = "вода", Order = 3, VendorServiceId = "1" });
            //    vendorService.Counters.Add(new Counter { Id = "3", Name = "вода", Order = 4, VendorServiceId = "1" });
            //    vendorService.Counters.Add(new Counter { Id = "3", Name = "вода", Order = 5, VendorServiceId = "1" });
            //    vendorService.Counters.Add(new Counter { Id = "3", Name = "вода", Order = 6, VendorServiceId = "1" });

            //    return vendorServices;
            //});

            return allServices;
        }
        
        public List<VendorService> GetVendorServiceByVendorId(string vendorId)
        {
            return GetVendorServices().Where(x => x.VendorId == vendorId).ToList(); 
        }

        public VendorService GetVendorServiceById(string vendorServiceId)
        {

            return GetVendorServices().First(x => x.Id== vendorServiceId);
        }
        #endregion


        #region Account

        public AccountInfo CheckPay(CheckPayCommandParams param)
        {
            using (var command = new CheckPayCommand(_settingService.GetServerIP(), _settingService.GetPort(), _currentUser, param))
            {
                command.Execute();
                if (!command.Success)
                {
                    throw new CheckPayException(command.ErrorMessage);
                }
                else
                {
                    return command.AccountInfo;
                }

            }
        }

        #endregion

        #region payments

        public List<Payment> GetPayments()
        {
            var cachekey = CACHE_PAYMENTS;

            return GetCacheKey<List<Payment>>(cachekey, () =>
            {
                //if (not) ask server
                var vendors = new List<Payment>();
                return vendors;
            });
        }
        
        public void AddPay(Payment payment)
        {

            using (var command = new DoPayCommand(_settingService.GetServerIP(), _settingService.GetPort(), _currentUser, new List<Payment>() { payment }))
            {
                command.Execute();
                if (!command.Success)
                {
                    throw new DoPayException(command.ErrorMessage);
                }
                else
                {
                    if (command.DoPayCommandResults.Count==0)
                        throw new DoPayException("Сервер не вернул результатов");
                    if (!command.DoPayCommandResults.First().Success)
                        throw new DoPayException(String.Format("{0}:{1}", command.DoPayCommandResults.First().ErrorCode, command.DoPayCommandResults.First().ErrorMessage));
                }

            }
            
            //Random rand=new Random();
            
            //passserver
            //payment.Id = "G" + rand.Next(1000, 100000000).ToString();
            //GetPayments().Add(payment);
        }

        public void EditPay(Payment payment)
        {
            //pass to server

            //var find=GetPayments().Remove(GetPayments().First(x => x.Id == payment.Id));
            //GetPayments().Add(payment);
        }

        public void DeletePayment(string id)
        {
            using (var command = new CancelPayCommand(_settingService.GetServerIP(),
                                                  _settingService.GetPort(),
                                                  _currentUser,
                                                  new List<Payment>() { new Payment { TransactionId = id } }))
            {
                command.Execute();
                if (!command.Success)
                {
                    throw new CancelPayException(command.ErrorMessage);
                }
                else
                {
                    if (command.CancelPayCommandResults.Count == 0)
                        throw new CancelPayException("Сервер не вернул результатов");
                    if (!command.CancelPayCommandResults.First().Success)
                        throw new CancelPayException(String.Format("{0}:{1}", command.CancelPayCommandResults.First().ErrorCode, command.CancelPayCommandResults.First().ErrorMessage));
                }

            }
        }

         public void CancelPayment(string transactionId)
         {
            using (var command = new CancelPayCommand(_settingService.GetServerIP(),
                                                 _settingService.GetPort(),
                                                 _currentUser,
                                                 new List<Payment>() { new Payment { TransactionId = transactionId } }))
            {
                command.Execute();
                if (!command.Success)
                {
                    throw new CancelPayException(command.ErrorMessage);
                }
                else
                {
                    if (command.CancelPayCommandResults.Count == 0)
                        throw new CancelPayException("Сервер не вернул результатов");
                    if (!command.CancelPayCommandResults.First().Success)
                        throw new CancelPayException(String.Format("{0}:{1}", command.CancelPayCommandResults.First().ErrorCode, command.CancelPayCommandResults.First().ErrorMessage));
                }

            }
        }

        public void ConfirmPay(string transactionId)
        {
            using (var command = new ConfirmPay(_settingService.GetServerIP(), 
                                                _settingService.GetPort(), 
                                                _currentUser, 
                                                new List<Payment>() { new Payment { TransactionId = transactionId } }))
            {
                command.Execute();
                if (!command.Success)
                {
                    throw new ConfirmPayException(command.ErrorMessage);
                }
                else
                {
                    if (command.ConfirmPayCommandResults.Count == 0)
                        throw new ConfirmPayException("Сервер не вернул результатов");
                    if (!command.ConfirmPayCommandResults.First().Success)
                        throw new ConfirmPayException(String.Format("{0}:{1}", command.ConfirmPayCommandResults.First().ErrorCode, command.ConfirmPayCommandResults.First().ErrorMessage));
                }

            }
        }
        #endregion


        public List<AccountInfo> SearchAccountServices(string barcode)
        {


            using (var command = new BarcodeCommand(_settingService.GetServerIP(),
                                               _settingService.GetPort(),
                                               _currentUser,
                                               barcode))
            {
                command.Execute();
                if (!command.Success)
                {
                    throw new CommandException(command.ErrorMessage);
                }
                else
                {
                    return command.AccountInfos;
                }

            }

        }
    } 
}
