namespace DatabaseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LineOne = c.String(),
                        LineTwo = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        CustomerId = c.String(nullable: false),
                        Customer_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Email)
                .Index(t => t.Customer_Email);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        DefaultAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Addresses", t => t.DefaultAddressId, cascadeDelete: true)
                .Index(t => t.DefaultAddressId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Specification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Stars = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.String(nullable: false),
                        Customer_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Email)
                .Index(t => t.ProductId)
                .Index(t => t.Customer_Email);
            
            CreateTable(
                "dbo.ProductCustomers",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Customer_Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Customer_Email })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Email, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Customer_Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Customer_Email", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCustomers", "Customer_Email", "dbo.Customers");
            DropForeignKey("dbo.ProductCustomers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Customers", "DefaultAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Customer_Email", "dbo.Customers");
            DropIndex("dbo.ProductCustomers", new[] { "Customer_Email" });
            DropIndex("dbo.ProductCustomers", new[] { "Product_Id" });
            DropIndex("dbo.Reviews", new[] { "Customer_Email" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Customers", new[] { "DefaultAddressId" });
            DropIndex("dbo.Addresses", new[] { "Customer_Email" });
            DropTable("dbo.ProductCustomers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
