namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesaleproduct5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_Product", "ProductSale_Id", "dbo.2121110054_ProductSale");
            DropForeignKey("dbo.2121110054_Product", "ProductSales_Id", "dbo.2121110054_ProductSale");

            DropIndex("dbo.2121110054_Product", new[] { "ProductSale_Id" });
            DropColumn("dbo.2121110054_Product", "ProductSale_Id");
            DropTable("dbo.2121110054_ProductSale");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.2121110054_ProductSale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        DiscountPrice = c.Decimal(precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.2121110054_Product", "ProductSale_Id", c => c.Int());
            CreateIndex("dbo.2121110054_Product", "ProductSale_Id");
            AddForeignKey("dbo.2121110054_Product", "ProductSale_Id", "dbo.2121110054_ProductSale", "Id");
        }
    }
}
