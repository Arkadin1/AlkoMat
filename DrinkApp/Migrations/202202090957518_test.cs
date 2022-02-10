namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeDrinks", "TypeDrinkId", c => c.Int(nullable: false));
            DropColumn("dbo.TypeDrinks", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeDrinks", "TypeId", c => c.Int(nullable: false));
            DropColumn("dbo.TypeDrinks", "TypeDrinkId");
        }
    }
}
