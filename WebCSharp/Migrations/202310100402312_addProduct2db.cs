namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProduct2db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Slug = c.String(),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        Detail = c.String(),
                        Sort_Order = c.Int(nullable: false),
                        Metakey = c.String(nullable: false, maxLength: 150),
                        Metadesc = c.String(nullable: false, maxLength: 150),
                        isHot = c.Boolean(nullable: false),
                        isHome = c.Boolean(nullable: false),
                        isFeature = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Brands_Id = c.Int(),
                        Categorys_Id = c.Int(),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Brand", t => t.Brands_Id)
                .ForeignKey("dbo.2121110054_Category", t => t.Categorys_Id)
                .ForeignKey("dbo.2121110054_Product", t => t.Products_Id)
                .Index(t => t.Brands_Id)
                .Index(t => t.Categorys_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.2121110054_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.2121110054_OrderDetail", "Product_Id1", c => c.Int());
            CreateIndex("dbo.2121110054_OrderDetail", "Product_Id1");
            AddForeignKey("dbo.2121110054_OrderDetail", "Product_Id1", "dbo.2121110054_Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_Product", "Products_Id", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_ProductImage", "ProductId", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_OrderDetail", "Product_Id1", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_Product", "Categorys_Id", "dbo.2121110054_Category");
            DropForeignKey("dbo.2121110054_Product", "Brands_Id", "dbo.2121110054_Brand");
            DropIndex("dbo.2121110054_ProductImage", new[] { "ProductId" });
            DropIndex("dbo.2121110054_OrderDetail", new[] { "Product_Id1" });
            DropIndex("dbo.2121110054_Product", new[] { "Products_Id" });
            DropIndex("dbo.2121110054_Product", new[] { "Categorys_Id" });
            DropIndex("dbo.2121110054_Product", new[] { "Brands_Id" });
            DropColumn("dbo.2121110054_OrderDetail", "Product_Id1");
            DropTable("dbo.2121110054_ProductImage");
            DropTable("dbo.2121110054_Product");
        }
    }
}
