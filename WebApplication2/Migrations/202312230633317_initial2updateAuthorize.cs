namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2updateAuthorize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookModels", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.BookModels", "Author", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.BookModels", "Description", c => c.String(maxLength: 2047));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookModels", "Description", c => c.String());
            AlterColumn("dbo.BookModels", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.BookModels", "Title", c => c.String(nullable: false));
        }
    }
}
