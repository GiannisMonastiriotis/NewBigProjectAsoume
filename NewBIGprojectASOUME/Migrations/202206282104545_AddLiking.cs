namespace NewBIGprojectASOUME.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddLiking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likings",
                c => new
                {
                    LikesId = c.String(nullable: false, maxLength: 128),
                    LikeeId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LikesId, t.LikeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.LikesId)
                .ForeignKey("dbo.AspNetUsers", t => t.LikeeId)
                .Index(t => t.LikesId)
                .Index(t => t.LikeeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Likings", "LikeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likings", "LikesId", "dbo.AspNetUsers");
            DropIndex("dbo.Likings", new[] { "LikeeId" });
            DropIndex("dbo.Likings", new[] { "LikesId" });
            DropTable("dbo.Likings");
        }
    }
}