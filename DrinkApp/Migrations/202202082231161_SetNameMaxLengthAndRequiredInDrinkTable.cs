namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameMaxLengthAndRequiredInDrinkTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drinks", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drinks", "Name", c => c.String());
        }
    }
}
