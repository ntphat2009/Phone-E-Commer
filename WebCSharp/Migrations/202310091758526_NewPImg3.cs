namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPImg3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                        Product_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Product", t => t.Product_Id1)
                .Index(t => t.Product_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });
            DropTable("dbo.2121110054_ProductImage");
        }
    }
}
