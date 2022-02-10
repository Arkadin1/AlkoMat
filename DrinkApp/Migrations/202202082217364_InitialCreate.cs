namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Sober = c.Boolean(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeDrinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        DrinkId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .Index(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeDrinks", "DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.Drinks", "GroupId", "dbo.Groups");
            DropIndex("dbo.TypeDrinks", new[] { "DrinkId" });
            DropIndex("dbo.Drinks", new[] { "GroupId" });
            DropTable("dbo.TypeDrinks");
            DropTable("dbo.Groups");
            DropTable("dbo.Drinks");
        }
    }
}
