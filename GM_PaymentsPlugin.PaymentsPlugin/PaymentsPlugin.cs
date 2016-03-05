using System.Text;
using GM_PaymentsPlugin.DataLayer;
using GM_PaymentsPlugin.PaymentsPlugin.Helpers;
using GM_PluginCommon.Payments;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using GM_PaymentsPlugin.Forms.Infrastructure;

namespace GM_PaymentsPlugin.PaymentsPlugin
{
    /// <summary>
    /// Реализация интерфейса плагина
    /// </summary>
    public sealed class PaymentsPlugin : IPaymentsPlugin
    {
        public PaymentsPlugin()
        {
            LogManager.CurrentLogger.Info("Plugin run");
            
            //LogManager.CurrentLogger.Info("server " + setServ.GetServerIP());
        }

        /// <summary>
        /// Объект для доступа к возможностям хоста
        /// </summary>
        public IPaymentsPluginHost Host { set; private get; }

        /// <summary>
        /// Получает список поставщиков
        /// </summary>
        public List<VendorInfo> GetVendorsList()
        {
            try
            {
                //ApplicationConfiguration.Instance.ConnectionString = Host.GetConnectionString();
                return VendorsHelper.DoGetVendorsList();
            }
            catch (Exception ex)
            {
                //Trace.TraceInformation(ex.Message);
                LogManager.CurrentLogger.Error("GetVendorsList error", ex);
                return new List<VendorInfo>();
            }
        }

        /// <summary>
        /// Получает список услуг
        /// </summary>
        public List<ServiceInfo> GetServicesList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Поиск поставщиков по параметрам
        /// </summary>
        public List<SearchResult> FindVendor(SearchInfo searchInfo)
        {
            try
            {
                //ApplicationConfiguration.Instance.ConnectionString = Host.GetConnectionString();
                return VendorsHelper.DoFindVendor(searchInfo);
            }
            catch (Exception ex)
            {
                LogManager.CurrentLogger.Error("FindVendor", ex);
                return new List<SearchResult>();
            }
        }

        public void BarcodeReceived(string barcode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получает список платежей
        /// </summary>
        public List<PaymentInfo> RecievePayments(RecievePaymentParameters recievePaymentParameters)
        {
            try
            {
                //ApplicationConfiguration.Instance.ConnectionString = Host.GetConnectionString();
                if (AutorizationHelper.CheckAutorizaton())
                {
                    return PaymentsHelper.DoRecievePayments(recievePaymentParameters);
                }

                return new List<PaymentInfo>();
            }
            catch (Exception ex)
            {
                LogManager.CurrentLogger.Error("GetVendorsList error", ex);
                return new List<PaymentInfo>();
            }
        }

        /// <summary>
        /// Подтверждение платежа
        /// </summary>
        public void PaymentConfirm(PaymentKeyInfo paymentKeyInfo)
        {
            try
            {
                //ApplicationConfiguration.Instance.ConnectionString = Host.GetConnectionString();
                if (AutorizationHelper.CheckAutorizaton())
                {
                    PaymentsHelper.DoPaymentConfirm(paymentKeyInfo);
                }
            }
            catch (Exception ex)
            {
                LogManager.CurrentLogger.Error("PaymentConfirm", ex);
            }
        }

        /// <summary>
        /// Отмена платежа
        /// </summary>
        public void PaymentCancel(PaymentKeyInfo paymentKeyInfo)
        {
            try
            {
                //ApplicationConfiguration.Instance.ConnectionString = Host.GetConnectionString();
                if (AutorizationHelper.CheckAutorizaton())
                {
                    PaymentsHelper.DoPaymentCancel(paymentKeyInfo);
                }
            }
            catch (Exception ex)
            {
                LogManager.CurrentLogger.Error("PaymentCancel", ex);
            }
        }
    }
}
