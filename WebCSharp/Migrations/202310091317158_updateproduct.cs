namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.2121110054_ProductImage", "Product_Id1", c => c.Int());
            AlterColumn("dbo.2121110054_ProductImage", "Image", c => c.String());
            AlterColumn("dbo.2121110054_ProductImage", "isDefault", c => c.Boolean(nullable: false));
            CreateIndex("dbo.2121110054_ProductImage", "Product_Id1");
            AddForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product", "Id");
            DropColumn("dbo.2121110054_Product", "Price_Sale");
            DropColumn("dbo.2121110054_Product", "isSale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.2121110054_Product", "isSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.2121110054_Product", "Price_Sale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });
            AlterColumn("dbo.2121110054_ProductImage", "isDefault", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_ProductImage", "Image", c => c.Int(nullable: false));
            DropColumn("dbo.2121110054_ProductImage", "Product_Id1");
        }
    }
}
