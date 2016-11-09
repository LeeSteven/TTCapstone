namespace TurboTechCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productOrders01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Master_TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Masters", t => t.Master_TransactionID)
                .Index(t => t.Master_TransactionID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Date = c.String(),
                        Image = c.String(),
                        CustomerId = c.Int(nullable: false),
                        Master_TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Masters", t => t.Master_TransactionID)
                .Index(t => t.CustomerId)
                .Index(t => t.Master_TransactionID);
            
            CreateTable(
                "dbo.OrderAndProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        Master_TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Masters", t => t.Master_TransactionID)
                .Index(t => t.Master_TransactionID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Master_TransactionID", "dbo.Masters");
            DropForeignKey("dbo.OrderAndProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderAndProducts", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Master_TransactionID", "dbo.Masters");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Master_TransactionID", "dbo.Masters");
            DropForeignKey("dbo.Logins", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Master_TransactionID" });
            DropIndex("dbo.OrderAndProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderAndProducts", new[] { "Order_OrderId" });
            DropIndex("dbo.Orders", new[] { "Master_TransactionID" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Logins", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "Master_TransactionID" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Products");
            DropTable("dbo.OrderAndProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Masters");
            DropTable("dbo.Logins");
            DropTable("dbo.Customers");
        }
    }
}
