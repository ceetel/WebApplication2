namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_phone_list : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "PhoneNumber", c => c.String());
        }
    }
}
