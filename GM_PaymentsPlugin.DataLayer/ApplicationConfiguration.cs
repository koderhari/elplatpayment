using System;

namespace GM_PaymentsPlugin.DataLayer
{
    /// <summary>
    /// Синглтон конфигурация плагина
    /// </summary>
    public class ApplicationConfiguration
    {
        private static ApplicationConfiguration _instance;

        private ApplicationConfiguration() {}

        public static ApplicationConfiguration Instance
        {
            get
            {
                return _instance ?? (_instance = new ApplicationConfiguration());
            }
        }

        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        public String ConnectionString { get; set; }
    }
}
