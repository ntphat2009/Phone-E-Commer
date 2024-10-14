namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefkproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_Product", "Products_Id", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_ProductStore", "Products_Id", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_Product", "Brands_Id", "dbo.2121110054_Brand");
            DropForeignKey("dbo.2121110054_Product", "Categorys_Id", "dbo.2121110054_Category");
            DropIndex("dbo.2121110054_Product", new[] { "Brands_Id" });
            DropIndex("dbo.2121110054_Product", new[] { "Categorys_Id" });
            DropIndex("dbo.2121110054_Product", new[] { "Products_Id" });
            DropIndex("dbo.2121110054_ProductStore", new[] { "Products_Id" });
            RenameColumn(table: "dbo.2121110054_Product", name: "Brands_Id", newName: "BrandId");
            RenameColumn(table: "dbo.2121110054_Product", name: "Categorys_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.2121110054_Product", name: "ProductSales_Id", newName: "ProductSale_Id");
            RenameIndex(table: "dbo.2121110054_Product", name: "IX_ProductSales_Id", newName: "IX_ProductSale_Id");
            AddColumn("dbo.2121110054_ProductSale", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Product", "BrandId", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Product", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.2121110054_Product", "CategoryId");
            CreateIndex("dbo.2121110054_Product", "BrandId");
            AddForeignKey("dbo.2121110054_Product", "BrandId", "dbo.2121110054_Brand", "Id", cascadeDelete: true);
            AddForeignKey("dbo.2121110054_Product", "CategoryId", "dbo.2121110054_Category", "Id", cascadeDelete: true);
            DropColumn("dbo.2121110054_Product", "Category_Id");
            DropColumn("dbo.2121110054_Product", "Brand_Id");
            DropColumn("dbo.2121110054_Product", "Products_Id");
            DropColumn("dbo.2121110054_ProductSale", "Product_Id");
            DropTable("dbo.2121110054_ProductStore");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.2121110054_ProductStore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.2121110054_ProductSale", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.2121110054_Product", "Products_Id", c => c.Int());
            AddColumn("dbo.2121110054_Product", "Brand_Id", c => c.Int(nullable: false));
            AddColumn("dbo.2121110054_Product", "Category_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.2121110054_Product", "CategoryId", "dbo.2121110054_Category");
            DropForeignKey("dbo.2121110054_Product", "BrandId", "dbo.2121110054_Brand");
            DropIndex("dbo.2121110054_Product", new[] { "BrandId" });
            DropIndex("dbo.2121110054_Product", new[] { "CategoryId" });
            AlterColumn("dbo.2121110054_Product", "CategoryId", c => c.Int());
            AlterColumn("dbo.2121110054_Product", "BrandId", c => c.Int());
            DropColumn("dbo.2121110054_ProductSale", "ProductId");
            RenameIndex(table: "dbo.2121110054_Product", name: "IX_ProductSale_Id", newName: "IX_ProductSales_Id");
            RenameColumn(table: "dbo.2121110054_Product", name: "ProductSale_Id", newName: "ProductSales_Id");
            RenameColumn(table: "dbo.2121110054_Product", name: "CategoryId", newName: "Categorys_Id");
            RenameColumn(table: "dbo.2121110054_Product", name: "BrandId", newName: "Brands_Id");
            CreateIndex("dbo.2121110054_ProductStore", "Products_Id");
            CreateIndex("dbo.2121110054_Product", "Products_Id");
            CreateIndex("dbo.2121110054_Product", "Categorys_Id");
            CreateIndex("dbo.2121110054_Product", "Brands_Id");
            AddForeignKey("dbo.2121110054_Product", "Categorys_Id", "dbo.2121110054_Category", "Id");
            AddForeignKey("dbo.2121110054_Product", "Brands_Id", "dbo.2121110054_Brand", "Id");
            AddForeignKey("dbo.2121110054_ProductStore", "Products_Id", "dbo.2121110054_Product", "Id");
            AddForeignKey("dbo.2121110054_Product", "Products_Id", "dbo.2121110054_Product", "Id");
        }
    }
}
