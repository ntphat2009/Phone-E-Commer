namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPImg : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
                 //"dbo.2121110054_ProductImage",
                 //c => new
                 //    {
                 //        Id = c.Int(nullable: false, identity: true),
                 //        Product_Id = c.Int(),
                 //        Image = c.String(),
                 //        isDefault = c.Boolean(nullable: false),

                 //    })
                 //.PrimaryKey(t => t.Id)
                 //.ForeignKey("dbo.2121110054_Product", t => t.Product_Id)
                 //.Index(t => t.Product_Id);
                 DropForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product");
                 DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id1", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });
            DropTable("dbo.2121110054_ProductImage");
        }
    }
}
