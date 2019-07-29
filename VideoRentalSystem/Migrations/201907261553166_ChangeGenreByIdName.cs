namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreByIdName : DbMigration
    {
        public override void Up()
        {
            RenameColumn("Movies", "GenreById", "GenreId");
        }
        
        public override void Down()
        {
        }
    }
}
