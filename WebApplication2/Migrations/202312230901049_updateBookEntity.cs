namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBookEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Book_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookModels", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerModels", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Customer_Id);
            
            AddColumn("dbo.BookModels", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.BookModels", "NumberAvailable", c => c.Int(nullable: false));
            Sql("UPDATE BookModels SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalViewModels", "Customer_Id", "dbo.CustomerModels");
            DropForeignKey("dbo.RentalViewModels", "Book_Id", "dbo.BookModels");
            DropIndex("dbo.RentalViewModels", new[] { "Customer_Id" });
            DropIndex("dbo.RentalViewModels", new[] { "Book_Id" });
            DropColumn("dbo.BookModels", "NumberAvailable");
            DropColumn("dbo.BookModels", "NumberInStock");
            DropTable("dbo.RentalViewModels");
        }
    }
}
