namespace NewBIGprojectASOUME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WTHISGOINGON : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bands", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bands", "DateCreated");
        }
    }
}
