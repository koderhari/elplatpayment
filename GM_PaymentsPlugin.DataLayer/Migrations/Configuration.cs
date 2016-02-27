using System.Data.Entity.Migrations;
using GM_PaymentsPlugin.DataLayer.Entities;

namespace GM_PaymentsPlugin.DataLayer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PaymentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PaymentsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Типы услуг

            context.PaymentTypes.AddOrUpdate(x => x.PaymentTypeId,
                new PaymentType { PaymentTypeId = "1", Name = "Коммунальные платежи" },
                new PaymentType { PaymentTypeId = "2", Name = "Сотовая связь" },
                new PaymentType { PaymentTypeId = "3", Name = "Электросвязь" },
                new PaymentType { PaymentTypeId = "4", Name = "Прочие" });
            var t = new PaymentType { PaymentTypeId = "5", Name = "Прочие2" };
            context.PaymentTypes.Add(t);

            #endregion

            #region Поставщики

            context.Vendors.AddOrUpdate(x => x.VendorId,
                new Vendor
                {
                    VendorId = "1",
                    INN = "8602067215",
                    KPP = "997450001",
                    Name = "ОАО «Тюменская энергосбытовая компания»",
                    Address =
                        "628406, Российская Федерация, Тюменская область, Ханты-Мансийский автономный округ- Югра, г. Сургут, Нижневартовское шоссе, 3, сооружение 7",
                    PhoneNumber = "+7 (3462) 77-77-77",
                    PaymentTypeId = "1"
                });

            #endregion

            context.SaveChanges();
        }
    }
}
