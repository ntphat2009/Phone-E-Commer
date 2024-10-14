namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductIMG2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                        
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });
            DropTable("dbo.2121110054_ProductImage");
        }
    }
}
