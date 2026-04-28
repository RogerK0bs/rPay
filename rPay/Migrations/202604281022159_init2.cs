namespace rPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAction", "patcient", c => c.String());
            AddColumn("dbo.UserAction", "amount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAction", "amount");
            DropColumn("dbo.UserAction", "patcient");
        }
    }
}
