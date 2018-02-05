namespace APIPio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poolnameedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "MaxFte", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "freeFte", c => c.Double(nullable: false));
            DropColumn("dbo.Employees", "MaxTfe");
            DropColumn("dbo.Employees", "freeTfe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "freeTfe", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "MaxTfe", c => c.Double(nullable: false));
            DropColumn("dbo.Employees", "freeFte");
            DropColumn("dbo.Employees", "MaxFte");
        }
    }
}
