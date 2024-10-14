namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImg : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "ProductId", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "ProductId" });
            DropTable("dbo.2121110054_ProductImage");
        }
    }
}
