namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE movies SET Genre='Horror' WHERE Title='The VVitch'");
        }
        
        public override void Down()
        {
        }
    }
}
