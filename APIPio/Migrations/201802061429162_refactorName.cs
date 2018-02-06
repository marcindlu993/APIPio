namespace APIPio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "EndDate");
        }
    }
}
