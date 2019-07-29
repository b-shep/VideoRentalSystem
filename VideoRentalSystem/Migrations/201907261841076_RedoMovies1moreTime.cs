namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedoMovies1moreTime : DbMigration
    {
        public override void Up()
        {
            DropTable("Movies");

            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    GenreId = c.Int(),
                    ReleaseDate = c.DateTime(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    NumberInStock = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);


            string now = DateTime.Now.ToString();
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('Django Unchained', 2, '2012-12-11', '" + now + "', 5)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('The VVitch', 3, '2015-01-23', '" + now + "', 2)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Sorry to Bother You', 4, '2018-07-13', '" + now + "', 10)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Midsommar', 3, '2019-06-24', '" + now + "', 3)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Gummo', 2, '1997-08-29', '" + now + "', 1)");

        }

        public override void Down()
        {
        }
    }
}
