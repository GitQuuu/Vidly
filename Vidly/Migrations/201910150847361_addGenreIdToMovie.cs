namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreIdToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            DropPrimaryKey("dbo.Genres");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Genres", "GenreId");
            AddPrimaryKey("dbo.Genres", "Id");
        }
    }
}
