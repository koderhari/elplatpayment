using GM_PaymentsPlugin.DataLayer.Entities;
using GM_PaymentsPlugin.DataLayer.Migrations;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace GM_PaymentsPlugin.DataLayer
{
    /// <summary>
    /// Контекст для работы с БД платежей
    /// </summary>
    [DbConfigurationType(typeof(PaymentContextConfiguration))]
    public class PaymentsContext : DbContext
    {
        public PaymentsContext()
            : base(ApplicationConfiguration.Instance.ConnectionString)
            // todo: Использовать только когда нужно создать новую миграцию... Из релиза исключить!!!
            //: base("Data Source=SERGPCSRV;Initial Catalog=PaymentsDB;Integrated Security=True;")
        {
            //Установим инициализатор БД
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaymentsContext, Configuration>());

            //Конфигурация контекста
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        /// <summary>
        /// Платежи
        /// </summary>
        public DbSet<PaymentOld> Payments { get; set; }

        /// <summary>
        /// Типы платежей
        /// </summary>
        public DbSet<PaymentType> PaymentTypes { get; set; }

        /// <summary>
        /// Поставщики
        /// </summary>
        public DbSet<Vendor> Vendors { get; set; }
    }

    /// <summary>
    /// Конфигурация контекста
    /// </summary>
    public class PaymentContextConfiguration : DbConfiguration
    {
        public PaymentContextConfiguration()
        {
            // т.к. нет файла конфигурации, зарегистрируем провайдера доступа к SQL Server здесь
            SetProviderServices(
                SqlProviderServices.ProviderInvariantName,
                SqlProviderServices.Instance);
        }
    }
}
