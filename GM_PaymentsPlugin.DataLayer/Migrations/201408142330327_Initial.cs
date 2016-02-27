namespace GM_PaymentsPlugin.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        INN = c.String(nullable: false, maxLength: 128),
                        KPP = c.String(nullable: false, maxLength: 128),
                        PaymentId = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountComission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonalNumber = c.String(),
                        ClientFullName = c.String(),
                        ClientAddress = c.String(),
                        PaymentTypeId = c.String(maxLength: 128),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.INN, t.KPP, t.PaymentId })
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.Vendors", t => new { t.INN, t.KPP }, cascadeDelete: true)
                .Index(t => new { t.INN, t.KPP })
                .Index(t => t.PaymentTypeId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentTypeId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        INN = c.String(nullable: false, maxLength: 128),
                        KPP = c.String(nullable: false, maxLength: 128),
                        VendorId = c.String(),
                        PaymentTypeId = c.String(maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => new { t.INN, t.KPP })
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .Index(t => t.PaymentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.Payments", new[] { "INN", "KPP" }, "dbo.Vendors");
            DropForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.Vendors", new[] { "PaymentTypeId" });
            DropIndex("dbo.Payments", new[] { "PaymentTypeId" });
            DropIndex("dbo.Payments", new[] { "INN", "KPP" });
            DropTable("dbo.Vendors");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Payments");
        }
    }
}
