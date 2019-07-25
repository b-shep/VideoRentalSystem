namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameColumnToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE MembershipType ADD COLUMN Name VARCHAR(50)");
        }
        
        public override void Down()
        {
        }
    }
}
