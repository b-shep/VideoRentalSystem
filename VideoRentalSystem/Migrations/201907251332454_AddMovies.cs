namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            string now = DateTime.Now.ToString();

            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('Django Unchained', 'Action', '2012-12-11', '" + now + "', 5)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('The VVitch', 'Horror', '2015-01-23', '" + now + "', 2)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Sorry to Bother You', 'Comedy', '2018-07-13', '" + now + "', 10)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Midsommar', 'Horror', '2019-06-24', '" + now + "', 3)");
            Sql("INSERT INTO Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Gummo', 'Documentary', '1997-08-29', '" + now + "', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
