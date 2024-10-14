namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesaleproduct2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_Product", "ProductSaleId", "dbo.2121110054_ProductSale");
            DropIndex("dbo.2121110054_Product", new[] { "ProductSaleId" });
            RenameColumn(table: "dbo.2121110054_Product", name: "ProductSaleId", newName: "ProductSale_Id");
            AlterColumn("dbo.2121110054_Product", "ProductSale_Id", c => c.Int());
            CreateIndex("dbo.2121110054_Product", "ProductSale_Id");
            AddForeignKey("dbo.2121110054_Product", "ProductSale_Id", "dbo.2121110054_ProductSale", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_Product", "ProductSale_Id", "dbo.2121110054_ProductSale");
            DropIndex("dbo.2121110054_Product", new[] { "ProductSale_Id" });
            AlterColumn("dbo.2121110054_Product", "ProductSale_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.2121110054_Product", name: "ProductSale_Id", newName: "ProductSaleId");
            CreateIndex("dbo.2121110054_Product", "ProductSaleId");
            AddForeignKey("dbo.2121110054_Product", "ProductSaleId", "dbo.2121110054_ProductSale", "Id", cascadeDelete: true);
        }
    }
}
