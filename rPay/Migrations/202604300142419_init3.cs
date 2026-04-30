namespace rPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAction", "date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAction", "date");
        }
    }
}
