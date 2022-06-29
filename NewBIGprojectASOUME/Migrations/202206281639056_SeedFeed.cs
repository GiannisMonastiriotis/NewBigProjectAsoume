namespace NewBIGprojectASOUME.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedFeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Jazz')");
            Sql("INSERT INTO Genres (Name) VALUES ('Blues')");
            Sql("INSERT INTO Genres (Name) VALUES ('Rock')");
            Sql("INSERT INTO Genres (Name) VALUES ('Metal')");
            Sql("INSERT INTO Genres (Name) VALUES ('Hip Hop')");
            Sql("INSERT INTO Genres (Name) VALUES ('Punk')");
            Sql("INSERT INTO Genres (Name) VALUES ('Rock And Roll')");
            Sql("INSERT INTO Genres (Name) VALUES ('House')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4,5,6,7,8)");
        }
    }
}