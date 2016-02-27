using System;
using System.Collections.Generic;
using GM_PluginCommon.Payments;

namespace GM_PaymentsPlugin.PaymentsPlugin.Helpers
{
    public static class VendorsHelper
    {
        /// <summary>
        /// Получает список поставщиков
        /// </summary>
        public static List<VendorInfo> DoGetVendorsList()
        {
            // Согласно функциональному дизайну всегда возвращает пустой список
            return new List<VendorInfo>();
        }

        /// <summary>
        /// Поиск поставщиков по параметрам
        /// </summary>
        public static List<SearchResult> DoFindVendor(SearchInfo searchInfo)
        {
            // Согласно функциональному дизайну всегда возвращает пустой список
            return new List<SearchResult>();
        }
    }
}
