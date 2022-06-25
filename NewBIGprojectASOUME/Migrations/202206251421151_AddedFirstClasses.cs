namespace NewBIGprojectASOUME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFirstClasses : DbMigration
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
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistsBandsConnections", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Bands", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bands", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.ArtistsBandsConnections", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Bands", new[] { "User_Id" });
            DropIndex("dbo.Bands", new[] { "Genre_Id" });
            DropIndex("dbo.ArtistsBandsConnections", new[] { "ArtistId" });
            DropIndex("dbo.ArtistsBandsConnections", new[] { "BandId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Bands");
            DropTable("dbo.ArtistsBandsConnections");
            DropTable("dbo.Artists");
        }
    }
}
