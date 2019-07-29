namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE TABLE Genres (Id int, Name VARCHAR(25))");
            Sql("INSERT INTO Genres(Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres(Name) VALUES ('Action')");
            Sql("INSERT INTO Genres(Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES ('Documentary')");
            Sql("INSERT INTO Genres(Name) VALUES ('Thriller')");
            Sql("INSERT INTO Genres(Name) VALUES ('Sci-Fi')");

        }
        
        public override void Down()
        {
        }
    }
}
