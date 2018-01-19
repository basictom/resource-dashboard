namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fortheloveofgodjustwork : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tags", name: "Resource_id", newName: "Resources_id");
            RenameIndex(table: "dbo.Tags", name: "IX_Resource_id", newName: "IX_Resources_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tags", name: "IX_Resources_id", newName: "IX_Resource_id");
            RenameColumn(table: "dbo.Tags", name: "Resources_id", newName: "Resource_id");
        }
    }
}
