namespace NewBIGprojectASOUME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysPropertiesToGig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bands", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bands", new[] { "User_Id" });
            RenameColumn(table: "dbo.Bands", name: "User_Id", newName: "UserID");
            AddColumn("dbo.Bands", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Bands", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Bands", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Bands", "UserID");
            AddForeignKey("dbo.Bands", "UserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bands", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Bands", new[] { "UserID" });
            AlterColumn("dbo.Bands", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Bands", "Name", c => c.String());
            DropColumn("dbo.Bands", "GenreId");
            RenameColumn(table: "dbo.Bands", name: "UserID", newName: "User_Id");
            CreateIndex("dbo.Bands", "User_Id");
            AddForeignKey("dbo.Bands", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
