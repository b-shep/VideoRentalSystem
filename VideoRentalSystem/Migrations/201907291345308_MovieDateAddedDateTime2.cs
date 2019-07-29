namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDateAddedDateTime2 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ALTER COLUMN DateAdded datetime2");
        }
        
        public override void Down()
        {
        }
    }
}
