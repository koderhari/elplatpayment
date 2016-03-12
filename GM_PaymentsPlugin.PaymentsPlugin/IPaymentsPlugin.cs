using GM_PluginCommon;
using GM_PluginCommon.Hardware;
using GM_PluginCommon.Payments;

namespace ElPlat_PaymentsPlugin.PaymentsPlugin
{
    /// <summary>
    /// Интерфейс плагина
    /// </summary>
    public interface IPaymentsPlugin : IBasePlugin<IPaymentsPluginHost>, IScannerConsumer, IPluginPaymentService
    {
    }
}
