namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES('Deliver us from evil','Horror',25/02/2016,10/03/2019,4)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES('Spiderman','Action',05/10/2018,10/03/2019,2)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES('Joker','Crime',03/10/2019,10/03/2019,4)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES('Lord of the rings','Fantasy',27/05/2010,10/03/2019,4)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES('Tekken','Animation',11/04/2005,10/03/2019,4)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES('Mulan','Disney',25/02/2009,10/03/2019,4)");

        }

        public override void Down()
        {
        }
    }
}
