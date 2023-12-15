namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneAndDeleteBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "PhoneNumber", c => c.String());
            DropColumn("dbo.CustomerModels", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerModels", "Birthdate", c => c.DateTime());
            DropColumn("dbo.CustomerModels", "PhoneNumber");
        }
    }
}
