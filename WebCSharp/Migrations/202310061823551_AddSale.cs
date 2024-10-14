namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_ProductSale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Product", t => t.Products_Id)
                .Index(t => t.Products_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductSale", "Products_Id", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductSale", new[] { "Products_Id" });
            DropTable("dbo.2121110054_ProductSale");
        }
    }
}
