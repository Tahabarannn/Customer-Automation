namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminSkype = c.String(maxLength: 50),
                        AdminTelegram = c.String(maxLength: 50),
                        ServerIp = c.String(maxLength: 20),
                        GoogleCaptchaToken = c.String(maxLength: 60),
                        IsActiveID = c.Int(nullable: false),
                        AdminRoleID = c.Int(nullable: false),
                        ImageID = c.Int(),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.AdminRoles", t => t.AdminRoleID, cascadeDelete: false)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .ForeignKey("dbo.ProfileImages", t => t.ImageID)
                .Index(t => t.IsActiveID)
                .Index(t => t.AdminRoleID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.AdminRoles",
                c => new
                    {
                        AdminRoleID = c.Int(nullable: false, identity: true),
                        AdminRoleName = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.AdminRoleID);
            
            CreateTable(
                "dbo.IsActives",
                c => new
                    {
                        IsActiveID = c.Int(nullable: false, identity: true),
                        Active = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.IsActiveID);
            
            CreateTable(
                "dbo.Affiliates",
                c => new
                    {
                        AffID = c.Int(nullable: false, identity: true),
                        PartnerID = c.String(maxLength: 4),
                        AccountName = c.String(maxLength: 100),
                        Contact = c.String(maxLength: 40),
                        DailyPostNumber = c.String(maxLength: 2),
                        Commission = c.String(maxLength: 4),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CryptoWallet = c.String(maxLength: 34),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        SocialMediaLink = c.String(maxLength: 1000),
                        Comment = c.String(maxLength: 1000),
                        Image = c.String(maxLength: 100),
                        PassedDay = c.String(maxLength: 3),
                        BrandID = c.Int(nullable: false),
                        SocialMediaID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        IsActiveID = c.Int(nullable: false),
                        FraudID = c.Int(),
                    })
                .PrimaryKey(t => t.AffID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: false)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .ForeignKey("dbo.IsFrauds", t => t.FraudID)
                .ForeignKey("dbo.SocialMedias", t => t.SocialMediaID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: false)
                .Index(t => t.BrandID)
                .Index(t => t.SocialMediaID)
                .Index(t => t.StatusID)
                .Index(t => t.UserID)
                .Index(t => t.IsActiveID)
                .Index(t => t.FraudID);
            
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        AdID = c.Int(nullable: false, identity: true),
                        Post = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdID)
                .ForeignKey("dbo.Affiliates", t => t.AffID, cascadeDelete: false)
                .Index(t => t.AffID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        Product = c.String(maxLength: 25),
                        IsActiveID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandID)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .Index(t => t.IsActiveID);
            
            CreateTable(
                "dbo.IsFrauds",
                c => new
                    {
                        FraudId = c.Int(nullable: false, identity: true),
                        Fraud = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.FraudId);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaID = c.Int(nullable: false, identity: true),
                        SocialMediaPlatform = c.String(maxLength: 30),
                        IsActiveID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SocialMediaID)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .Index(t => t.IsActiveID);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormID = c.Int(nullable: false, identity: true),
                        FormDate = c.DateTime(),
                        AffMail = c.String(maxLength: 100),
                        Contact = c.String(maxLength: 50),
                        SocialMediaLink = c.String(maxLength: 1000),
                        WorkType = c.String(maxLength: 1000),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Explanation = c.String(maxLength: 1000),
                        Reference = c.String(maxLength: 100),
                        SocialMedia = c.String(maxLength: 50),
                        UserID = c.Int(),
                        AdminID = c.Int(),
                        IsActiveID = c.Int(nullable: false),
                        FormStatusID = c.Int(),
                        SocialMedia_SocialMediaID = c.Int(),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.Admins", t => t.AdminID)
                .ForeignKey("dbo.FormStatus", t => t.FormStatusID)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.SocialMedias", t => t.SocialMedia_SocialMediaID)
                .Index(t => t.UserID)
                .Index(t => t.AdminID)
                .Index(t => t.IsActiveID)
                .Index(t => t.FormStatusID)
                .Index(t => t.SocialMedia_SocialMediaID);
            
            CreateTable(
                "dbo.FormStatus",
                c => new
                    {
                        FormStatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.FormStatusID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 20),
                        Password = c.String(),
                        Skype = c.String(maxLength: 25),
                        Telegram = c.String(maxLength: 25),
                        ServerIp = c.String(maxLength: 20),
                        Title = c.String(maxLength: 30),
                        GoogleCaptchaToken = c.String(maxLength: 60),
                        IsActiveID = c.Int(nullable: false),
                        AdminID = c.Int(nullable: false),
                        ImageID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: false)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .ForeignKey("dbo.ProfileImages", t => t.ImageID)
                .Index(t => t.IsActiveID)
                .Index(t => t.AdminID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.ProfileImages",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        State = c.String(maxLength: 100),
                        IsActiveID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID)
                .ForeignKey("dbo.IsActives", t => t.IsActiveID, cascadeDelete: false)
                .Index(t => t.IsActiveID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Affiliates", "StatusID", "dbo.Status");
            DropForeignKey("dbo.SocialMedias", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Forms", "SocialMedia_SocialMediaID", "dbo.SocialMedias");
            DropForeignKey("dbo.Users", "ImageID", "dbo.ProfileImages");
            DropForeignKey("dbo.Admins", "ImageID", "dbo.ProfileImages");
            DropForeignKey("dbo.Users", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Forms", "UserID", "dbo.Users");
            DropForeignKey("dbo.Affiliates", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Forms", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Forms", "FormStatusID", "dbo.FormStatus");
            DropForeignKey("dbo.Forms", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Affiliates", "SocialMediaID", "dbo.SocialMedias");
            DropForeignKey("dbo.Affiliates", "FraudID", "dbo.IsFrauds");
            DropForeignKey("dbo.Affiliates", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Brands", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Affiliates", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Advertisements", "AffID", "dbo.Affiliates");
            DropForeignKey("dbo.Admins", "IsActiveID", "dbo.IsActives");
            DropForeignKey("dbo.Admins", "AdminRoleID", "dbo.AdminRoles");
            DropIndex("dbo.Status", new[] { "IsActiveID" });
            DropIndex("dbo.Users", new[] { "ImageID" });
            DropIndex("dbo.Users", new[] { "AdminID" });
            DropIndex("dbo.Users", new[] { "IsActiveID" });
            DropIndex("dbo.Forms", new[] { "SocialMedia_SocialMediaID" });
            DropIndex("dbo.Forms", new[] { "FormStatusID" });
            DropIndex("dbo.Forms", new[] { "IsActiveID" });
            DropIndex("dbo.Forms", new[] { "AdminID" });
            DropIndex("dbo.Forms", new[] { "UserID" });
            DropIndex("dbo.SocialMedias", new[] { "IsActiveID" });
            DropIndex("dbo.Brands", new[] { "IsActiveID" });
            DropIndex("dbo.Advertisements", new[] { "AffID" });
            DropIndex("dbo.Affiliates", new[] { "FraudID" });
            DropIndex("dbo.Affiliates", new[] { "IsActiveID" });
            DropIndex("dbo.Affiliates", new[] { "UserID" });
            DropIndex("dbo.Affiliates", new[] { "StatusID" });
            DropIndex("dbo.Affiliates", new[] { "SocialMediaID" });
            DropIndex("dbo.Affiliates", new[] { "BrandID" });
            DropIndex("dbo.Admins", new[] { "ImageID" });
            DropIndex("dbo.Admins", new[] { "AdminRoleID" });
            DropIndex("dbo.Admins", new[] { "IsActiveID" });
            DropTable("dbo.Status");
            DropTable("dbo.ProfileImages");
            DropTable("dbo.Users");
            DropTable("dbo.FormStatus");
            DropTable("dbo.Forms");
            DropTable("dbo.SocialMedias");
            DropTable("dbo.IsFrauds");
            DropTable("dbo.Brands");
            DropTable("dbo.Advertisements");
            DropTable("dbo.Affiliates");
            DropTable("dbo.IsActives");
            DropTable("dbo.AdminRoles");
            DropTable("dbo.Admins");
        }
    }
}
