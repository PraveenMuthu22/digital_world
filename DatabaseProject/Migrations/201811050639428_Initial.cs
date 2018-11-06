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
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Stars = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Product_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Catagory = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Specification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Reviews", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reviews", new[] { "Product_Id" });
            DropIndex("dbo.Reviews", new[] { "Customer_Id" });
            DropIndex("dbo.Addresses", new[] { "Customer_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Reviews");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
