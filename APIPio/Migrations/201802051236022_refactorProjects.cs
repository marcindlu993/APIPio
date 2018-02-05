namespace APIPio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorProjects : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Topics", newName: "Projects");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Projects", newName: "Topics");
        }
    }
}
