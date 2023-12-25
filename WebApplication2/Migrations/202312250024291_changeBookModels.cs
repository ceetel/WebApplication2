namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBookModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookModels", "Description", c => c.String(nullable: false, maxLength: 2047));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookModels", "Description", c => c.String(maxLength: 2047));
        }
    }
}
