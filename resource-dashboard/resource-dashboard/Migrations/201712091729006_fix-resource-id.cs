namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixresourceid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "ResourceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "ResourceId", c => c.Int(nullable: false));
        }
    }
}
