namespace NewBIGprojectASOUME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnModelCreatingIdentityModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtistsBandsConnections", "BandId", "dbo.Bands");
            AddForeignKey("dbo.ArtistsBandsConnections", "BandId", "dbo.Bands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistsBandsConnections", "BandId", "dbo.Bands");
            AddForeignKey("dbo.ArtistsBandsConnections", "BandId", "dbo.Bands", "Id", cascadeDelete: true);
        }
    }
}
