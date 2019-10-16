namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyToMovie : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            DropColumn("dbo.Genres", "Id");
            AddPrimaryKey("dbo.Genres", "GenreId");
        }
    }
}
