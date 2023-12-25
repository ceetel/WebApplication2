namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ae2a7d6-ec2d-414b-9b6b-a158f8813d03', N'admin@ceetel.com', 0, N'ABRcNsEuuE/OIv4KoCHVdfdbOYFJBDc3g9Evn5/IPjoJHY1R20NJvwj5vNbkqMCmPw==', N'329b1d01-55ea-4e0b-a817-b797f7d6e5e0', NULL, 0, 0, NULL, 1, 0, N'admin@ceetel.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a92eed8-eaa3-459b-a51a-9f2667a9ea8c', N'guest@ceetel.com', 0, N'AHiSEJCti+qFAB7iHa1WciXdtILULC3hfRhetnSiqKKzvLBsUy0YXFUMV8EKaUNNQQ==', N'86ed814b-0471-495d-8168-dfe8fdb1c27f', NULL, 0, 0, NULL, 1, 0, N'guest@ceetel.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'404f611b-83a8-4987-9cbf-b330df6609df', N'CanManageBooks')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1ae2a7d6-ec2d-414b-9b6b-a158f8813d03', N'404f611b-83a8-4987-9cbf-b330df6609df')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
