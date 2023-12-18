namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES (1,0,0,1,'免费帐户')");
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES (2,30,1,10,'月度订阅')");
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES (3,90,3,15,'季度订阅')");
            Sql("INSERT INTO MembershipTypeModels (Id,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES (4,300,12,20,'年度订阅')");
        }
        
        public override void Down()
        {
        }
    }
}
