namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        CategoryName = c.String(),
                        Resources_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Resources", t => t.Resources_id)
                .Index(t => t.Resources_id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Resources_id", "dbo.Resources");
            DropIndex("dbo.Categories", new[] { "Resources_id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Resources");
            DropTable("dbo.Categories");
        }
    }
}
