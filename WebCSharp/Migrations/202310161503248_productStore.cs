namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productStore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.2121110054_ProductSale", "Products_Id", c => c.Int());
            CreateIndex("dbo.2121110054_ProductSale", "Products_Id");
            AddForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product", "Id");
            DropColumn("dbo.2121110054_Product", "Qty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.2121110054_Product", "Qty", c => c.Int(nullable: false));
            DropForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductSale", new[] { "Products_Id" });
            DropColumn("dbo.2121110054_ProductSale", "Products_Id");
        }
    }
}
