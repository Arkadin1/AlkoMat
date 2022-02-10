namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "Time", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drinks", "Time");
        }
    }
}
