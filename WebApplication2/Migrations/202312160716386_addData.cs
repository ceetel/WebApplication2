namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFree,DurationInMonths,DiscountRate,Name) VALUES (1,0,0,1,'Free Account')");
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFree,DurationInMonths,DiscountRate,Name) VALUES (2,30,1,10,'Monthly Subscription')");
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFree,DurationInMonths,DiscountRate,Name) VALUES (3,90,3,15,'Quarterly Subscription')");
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFree,DurationInMonths,DiscountRate,Name) VALUES (4,300,12,20,'Annual Subscription')");
        }
        
        public override void Down()
        {
        }
    }
}
