namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIndexImg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_ProductImage", "Product_Id", "dbo.2121110054_Product");
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id" });
        }
        
        public override void Down()
        {
        }
    }
}
