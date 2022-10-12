namespace Call_Controller_ReactJS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.StoreID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "StoreID", "dbo.Store");
            DropForeignKey("dbo.Sale", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Sale", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Sale", new[] { "ProductID" });
            DropIndex("dbo.Sale", new[] { "StoreID" });
            DropIndex("dbo.Sale", new[] { "CustomerID" });
            DropTable("dbo.Store");
            DropTable("dbo.Product");
            DropTable("dbo.Sale");
            DropTable("dbo.Customer");
        }
    }
}
