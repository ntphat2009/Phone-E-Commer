namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStore : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Product", t => t.Products_Id)
                .Index(t => t.Products_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductStore", "Products_Id", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductStore", new[] { "Products_Id" });
            DropTable("dbo.2121110054_ProductStore");
        }
    }
}
