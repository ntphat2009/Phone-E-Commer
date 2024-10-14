namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesaleproduct3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_Product", "ProductSale_Id", "dbo.2121110054_ProductSale");
            DropIndex("dbo.2121110054_Product", new[] { "ProductSale_Id" });
            RenameColumn(table: "dbo.2121110054_Product", name: "ProductSale_Id", newName: "ProductSaleId");
            AlterColumn("dbo.2121110054_Product", "ProductSaleId", c => c.Int(nullable: false));
            CreateIndex("dbo.2121110054_Product", "ProductSaleId");
            AddForeignKey("dbo.2121110054_Product", "ProductSaleId", "dbo.2121110054_ProductSale", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_Product", "ProductSaleId", "dbo.2121110054_ProductSale");
            DropIndex("dbo.2121110054_Product", new[] { "ProductSaleId" });
            AlterColumn("dbo.2121110054_Product", "ProductSaleId", c => c.Int());
            RenameColumn(table: "dbo.2121110054_Product", name: "ProductSaleId", newName: "ProductSale_Id");
            CreateIndex("dbo.2121110054_Product", "ProductSale_Id");
            AddForeignKey("dbo.2121110054_Product", "ProductSale_Id", "dbo.2121110054_ProductSale", "Id");
        }
    }
}
