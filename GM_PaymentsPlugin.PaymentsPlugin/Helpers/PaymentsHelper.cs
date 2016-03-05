using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using GM_PaymentsPlugin.DataLayer;
using GM_PaymentsPlugin.DataLayer.Entities;
using GM_PaymentsPlugin.Forms;
using GM_PluginCommon.Payments;
using GM_PaymentsPlugin.Forms.Infrastructure;

namespace GM_PaymentsPlugin.PaymentsPlugin.Helpers
{
    public static class PaymentsHelper
    {
        /// <summary>
        /// Получает список платежей
        /// </summary>
        public static List<PaymentInfo> DoRecievePayments(RecievePaymentParameters parameters)
        {
            var result = new List<PaymentInfo>();
            List<Payment> payments = null;

            SettingService setServ = new SettingService();
            var authService = new AuthenticationService(setServ);
            
            var paymentsService = new PaymentService(authService.CurrentUser, setServ);
            using (var form = new PaymentsCartForm(new PaymentsCartFormSettings { SingleMode = !parameters.IsMultiMode }, paymentsService))
            {
                form.ShowDialog();
                payments = form.Payments.ToList();
            }
            payments.ForEach(p => result.Add(MapPaymentToHost(p, paymentsService)));

            return result;
        }

        /// <summary>
        /// Подтверждение платежа
        /// </summary>
        public static void DoPaymentConfirm(PaymentKeyInfo paymentKeyInfo)
        {
            SettingService setServ = new SettingService();
            var authService = new AuthenticationService(setServ);
            
            var paymentsService = new PaymentService(authService.CurrentUser, setServ);
            paymentsService.ConfirmPay(paymentKeyInfo.PaymentId);
        }

        /// <summary>
        /// Отмена платежа
        /// </summary>
        public static void DoPaymentCancel(PaymentKeyInfo paymentKeyInfo)
        {
            SettingService setServ = new SettingService();
            var authService = new AuthenticationService(setServ);
            
            var paymentsService = new PaymentService(authService.CurrentUser, setServ);
            paymentsService.DeletePayment(paymentKeyInfo.PaymentId);
        }

        #region Вспомогательные методы

        /// <summary>
        /// Конфигурация для формы приема платежей
        /// </summary>
        //private static RecievePaymentsFormSettings GetRecievePaymentsFormSettings(RecievePaymentParameters parameters,
        //    PaymentsContext context)
        //{
        //    // Подготовим конфигурацию формы
        //    var formSettings = new RecievePaymentsFormSettings()
        //    {
        //        IsMultiMode = parameters.IsMultiMode
        //    };

        //    formSettings.AvailablePaymentTypes = context.PaymentTypes.ToList();
        //    formSettings.AvailableVendors = context.Vendors.ToList();

        //    // Согласно функциональному дизайну в данном случае есть только один поставщик и один тип перевода
        //    //formSettings.CurrentPaymentType = context.PaymentTypes.FirstOrDefault(p => p.PaymentTypeId == "1");
        //    //formSettings.CurrentVendor = context.Vendors.FirstOrDefault();

        //    formSettings.CurrentPaymentType =
        //        context.PaymentTypes.FirstOrDefault(p => p.PaymentTypeId == ((int) parameters.PaymentType).ToString());

        //    if (parameters.VendorKeyInfo != null &&
        //        !String.IsNullOrEmpty(parameters.VendorKeyInfo.INN) &&
        //        !String.IsNullOrEmpty(parameters.VendorKeyInfo.KPP))
        //    {
        //        formSettings.CurrentVendor = context.Vendors.FirstOrDefault(v =>
        //            v.INN.Equals(parameters.VendorKeyInfo.INN) &&
        //            v.KPP.Equals(parameters.VendorKeyInfo.KPP) &&
        //            v.PaymentTypeId.Equals(((int) parameters.PaymentType).ToString()));
        //    }

        //    return formSettings;
        //}

        /// <summary>
        /// Маппинг платежа в структуру понятную хосту
        /// </summary>
        private static PaymentInfo MapPaymentToHost(Payment payment,PaymentService paymentService)
        {
            var vendor = paymentService.GetVendorById(payment.VendorId);
            return new PaymentInfo()
            {
                PaymentId = payment.Id,
                Amount = payment.Amount,
                AmountComission = payment.AmountComission,
                Description = payment.Description,
                VendorKeyInfo = new VendorKeyInfo()
                {
                    INN = vendor.INN,
                    KPP = vendor.KPP
                },
                ClientInfo = new ClientInfo()
                {
                    FirstName = payment.ClientFullName,
                    PersonalNumber = payment.PersonalNumber,
                    Address = payment.ClientAddress
                },
                ServiceKeyInfo = new ServiceKeyInfo()
                {
                    ServiceId = payment.PaymentTypeId
                }
            };
        }

        #endregion

    }
}
