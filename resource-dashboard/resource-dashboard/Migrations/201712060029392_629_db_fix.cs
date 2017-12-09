namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _629_db_fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "Category", c => c.String());
            DropColumn("dbo.Resources", "Categories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "Categories", c => c.String());
            DropColumn("dbo.Resources", "Category");
        }
    }
}
