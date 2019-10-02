using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBirthdayColummInCustomers : DbMigration
    {
        public override void Up()
        {
            RenameColumn("Customers","Birthday","Birthdate");
        }
        
        public override void Down()
        {
        }
    }
}
