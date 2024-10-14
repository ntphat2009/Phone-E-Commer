namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductSale", new[] { "Products_Id" });
            AddColumn("dbo.2121110054_Product", "ProductSales_Id", c => c.Int());
            CreateIndex("dbo.2121110054_Product", "ProductSales_Id");
            AddForeignKey("dbo.2121110054_Product", "ProductSales_Id", "dbo.2121110054_ProductSale", "Id");
            DropColumn("dbo.2121110054_ProductSale", "Products_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.2121110054_ProductSale", "Products_Id", c => c.Int());
            DropForeignKey("dbo.2121110054_Product", "ProductSales_Id", "dbo.2121110054_ProductSale");
            DropIndex("dbo.2121110054_Product", new[] { "ProductSales_Id" });
            DropColumn("dbo.2121110054_Product", "ProductSales_Id");
            CreateIndex("dbo.2121110054_ProductSale", "Products_Id");
            AddForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product", "Id");
        }
    }
}
