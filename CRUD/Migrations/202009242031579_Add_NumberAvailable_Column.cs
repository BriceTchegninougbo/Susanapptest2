namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_NumberAvailable_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));

            Sql("Update Movies Set NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
