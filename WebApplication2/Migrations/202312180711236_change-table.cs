namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypeModels", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypeModels", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypeModels", "SignUpFree", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypeModels", "SignUpFee");
        }
    }
}
