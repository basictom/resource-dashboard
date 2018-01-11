namespace resource_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "Date");
        }
    }
}
