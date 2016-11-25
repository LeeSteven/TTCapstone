namespace TurboTechCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Province", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Province");
            DropColumn("dbo.Customers", "Address");
        }
    }
}
