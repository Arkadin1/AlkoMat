namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drinks", "Weight", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drinks", "Weight", c => c.Int(nullable: false));
        }
    }
}
