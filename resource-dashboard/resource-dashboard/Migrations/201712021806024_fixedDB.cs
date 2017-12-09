namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Resources_id", "dbo.Resources");
            DropIndex("dbo.Categories", new[] { "Resources_id" });
            AddColumn("dbo.Resources", "Categories", c => c.String());
            AddColumn("dbo.Resources", "Categories_id", c => c.Int());
            AddColumn("dbo.Tags", "Resources_id", c => c.Int());
            CreateIndex("dbo.Resources", "Categories_id");
            CreateIndex("dbo.Tags", "Resources_id");
            AddForeignKey("dbo.Tags", "Resources_id", "dbo.Resources", "id");
            AddForeignKey("dbo.Resources", "Categories_id", "dbo.Categories", "id");
            DropColumn("dbo.Categories", "Resources_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Resources_id", c => c.Int());
            DropForeignKey("dbo.Resources", "Categories_id", "dbo.Categories");
            DropForeignKey("dbo.Tags", "Resources_id", "dbo.Resources");
            DropIndex("dbo.Tags", new[] { "Resources_id" });
            DropIndex("dbo.Resources", new[] { "Categories_id" });
            DropColumn("dbo.Tags", "Resources_id");
            DropColumn("dbo.Resources", "Categories_id");
            DropColumn("dbo.Resources", "Categories");
            CreateIndex("dbo.Categories", "Resources_id");
            AddForeignKey("dbo.Categories", "Resources_id", "dbo.Resources", "id");
        }
    }
}
