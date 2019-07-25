namespace VideoRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameDataMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET DiscountRate=0 WHERE Id=1");
            Sql("UPDATE MembershipTypes SET DiscountRate=10 WHERE Id=2");
            Sql("UPDATE MembershipTypes SET DiscountRate=15 WHERE Id=3");
            Sql("UPDATE MembershipTypes SET DiscountRate=30 WHERE Id=4");

            Sql("UPDATE MembershipTypes SET Name='PayAsYouGo' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name='Annually' WHERE Id=4");
        }
        
        public override void Down()
        {

        }
    }
}
