namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppctId1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });
            DropTable("dbo.2121110054_ProductImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.2121110054_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                        Product_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.2121110054_ProductImage", "Product_Id1");
            AddForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product", "Id");
        }
    }
}
