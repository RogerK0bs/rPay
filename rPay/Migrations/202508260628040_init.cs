namespace rPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentReceipt",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        account = c.String(),
                        additionalInfo = c.String(),
                        amount = c.Single(nullable: false),
                        currency = c.String(),
                        order = c.String(),
                        paymentDetails = c.String(),
                        qrType = c.String(),
                        qrExpirationDate = c.String(),
                        sbpMerchantId = c.String(),
                        redirectUrl = c.String(),
                        qrDescription = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PayStatus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        additionalInfo = c.String(),
                        paymentPurpose = c.String(),
                        amount = c.Single(nullable: false),
                        code = c.String(),
                        createDate = c.String(),
                        currency = c.String(),
                        order = c.String(),
                        paymentStatus = c.String(),
                        qrId = c.String(),
                        sbpMerchantId = c.String(),
                        transactionDate = c.String(),
                        transactionId = c.String(),
                        qrExpirationDate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RespPayment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        qrId = c.String(),
                        payload = c.String(),
                        qrUrl = c.String(),
                        subscriptionId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserAction",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        action = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Permissions = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserAction");
            DropTable("dbo.RespPayment");
            DropTable("dbo.PayStatus");
            DropTable("dbo.PaymentReceipt");
        }
    }
}
