namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerBirthdates : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='1990-10-20' WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
