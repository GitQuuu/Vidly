namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBithdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers","Birthdate",c=> c.DateTime(nullable:true));
        }
        
        public override void Down()
        {
        }
    }
}
