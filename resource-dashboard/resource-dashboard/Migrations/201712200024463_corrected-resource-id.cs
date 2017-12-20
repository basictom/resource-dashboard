namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedresourceid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tags", new[] { "Resources_id" });
            AlterColumn("dbo.Tags", "Resources_id", c => c.Int());
            CreateIndex("dbo.Tags", "Resources_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tags", new[] { "Resources_id" });
            AlterColumn("dbo.Tags", "Resources_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tags", "Resources_id");
        }
    }
}
