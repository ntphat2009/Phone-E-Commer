namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropImg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id" });
            DropIndex("dbo.2121110054_ProductSale", new[] { "Products_Id" });
            DropColumn("dbo.2121110054_ProductSale", "Products_Id");
            DropTable("dbo.2121110054_ProductImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.2121110054_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id1 = c.Int(nullable: false),
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.2121110054_ProductSale", "Products_Id", c => c.Int());
            CreateIndex("dbo.2121110054_ProductSale", "Products_Id");
            CreateIndex("dbo.2121110054_ProductImage", "Product_Id");
            AddForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product", "Id");
            AddForeignKey("dbo.2121110054_ProductImage", "Product_Id", "dbo.2121110054_Product", "Id");
        }
    }
}
