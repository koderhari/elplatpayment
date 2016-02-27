using GM_PluginCommon;
using GM_PluginCommon.Hardware;
using GM_PluginCommon.Payments;

namespace GM_PaymentsPlugin.PaymentsPlugin
{
    /// <summary>
    /// Интерфейс плагина
    /// </summary>
    public interface IPaymentsPlugin : IBasePlugin<IPaymentsPluginHost>, IScannerConsumer, IPluginPaymentService
    {
    }
}
