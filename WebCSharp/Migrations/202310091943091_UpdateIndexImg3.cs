namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIndexImg3 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.2121110054_ProductImage", "Product_Id");
            DropForeignKey("dbo.2121110054_Product", "Product_Id", "dbo.2121110054_ProductImage");
        }
        
        public override void Down()
        {
        }
    }
}
