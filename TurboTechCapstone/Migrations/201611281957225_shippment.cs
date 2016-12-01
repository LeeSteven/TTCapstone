namespace TurboTechCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shippment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Shippment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Shippment");
        }
    }
}
