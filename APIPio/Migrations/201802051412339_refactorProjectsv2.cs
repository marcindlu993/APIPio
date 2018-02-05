namespace APIPio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorProjectsv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IsActive");
            DropColumn("dbo.Employees", "IsActive");
        }
    }
}
