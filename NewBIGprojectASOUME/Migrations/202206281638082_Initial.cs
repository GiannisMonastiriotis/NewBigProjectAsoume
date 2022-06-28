namespace NewBIGprojectASOUME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistsBandsConnections",
                c => new
                    {
                        BandId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BandId, t.ArtistId })
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Bands", t => t.BandId)
                .Index(t => t.BandId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateCreated = c.DateTime(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        BandId = c.Int(nullable: false),
                        LikedId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BandId, t.LikedId })
                .ForeignKey("dbo.Bands", t => t.BandId)
                .ForeignKey("dbo.AspNetUsers", t => t.LikedId, cascadeDelete: true)
                .Index(t => t.BandId)
                .Index(t => t.LikedId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Likes", "LikedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "BandId", "dbo.Bands");
            DropForeignKey("dbo.ArtistsBandsConnections", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Bands", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bands", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.ArtistsBandsConnections", "ArtistId", "dbo.Artists");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Likes", new[] { "LikedId" });
            DropIndex("dbo.Likes", new[] { "BandId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Bands", new[] { "GenreId" });
            DropIndex("dbo.Bands", new[] { "UserID" });
            DropIndex("dbo.ArtistsBandsConnections", new[] { "ArtistId" });
            DropIndex("dbo.ArtistsBandsConnections", new[] { "BandId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Likes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Genres");
            DropTable("dbo.Bands");
            DropTable("dbo.ArtistsBandsConnections");
            DropTable("dbo.Artists");
        }
    }
}
