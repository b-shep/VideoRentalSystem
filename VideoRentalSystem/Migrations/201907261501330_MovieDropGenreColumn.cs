namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDropGenreColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre");
            Sql("ALTER TABLE Movies ADD GenreById int");
        }
        
        public override void Down()
        {

        }
    }
}
