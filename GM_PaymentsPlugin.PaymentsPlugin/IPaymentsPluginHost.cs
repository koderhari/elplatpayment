using GM_PluginCommon.DBAccess;
using GM_PluginCommon.Hardware;

namespace ElPlat_PaymentsPlugin.PaymentsPlugin
{
    /// <summary>
    /// Интерфейс хоста
    /// </summary>
    public interface IPaymentsPluginHost : IScannerAccess, IDBAccess /*, ITerminalInfo*/
    {
    }
}
