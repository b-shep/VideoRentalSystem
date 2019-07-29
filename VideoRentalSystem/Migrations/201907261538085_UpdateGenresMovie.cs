namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenresMovie : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE movies SET GenreById=3 WHERE id=1");
            Sql("UPDATE movies SET GenreById=2 WHERE id=2");
            Sql("UPDATE movies SET GenreById=3 WHERE id=3");
            Sql("UPDATE movies SET GenreById=3 WHERE id=4");
            Sql("UPDATE movies SET GenreById=3 WHERE id=5");
            Sql("UPDATE movies SET GenreById=3 WHERE id=6");
        }
        
        public override void Down()
        {
        }
    }
}
