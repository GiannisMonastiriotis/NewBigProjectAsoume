namespace NewBIGprojectASOUME.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PROBABLYTOGOBACK : DbMigration
    {
        public override void Up()
        {
        }

        public override void Down()
        {
            DropForeignKey("dbo.ArtistsBandsConnections", "ArtistId", "dbo.Artists");
            AddForeignKey("dbo.ArtistsBandsConnections", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
    }
}