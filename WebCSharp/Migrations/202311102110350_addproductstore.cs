namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproductstore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_ProductStore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductStore", "ProductId", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductStore", new[] { "ProductId" });
            DropTable("dbo.2121110054_ProductStore");
        }
    }
}
