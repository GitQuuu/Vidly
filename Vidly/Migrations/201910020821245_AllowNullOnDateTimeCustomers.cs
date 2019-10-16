using System.Web.Mvc;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullOnDateTimeCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Customers","Birthdate", C=> C.DateTime(true));
        }
        
        public override void Down()
        {
        }
    }
}
