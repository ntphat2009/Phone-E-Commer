namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPImg4 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id1" });
            //DropColumn("dbo.2121110054_ProductImage", "Product_Id");
            //RenameColumn(table: "dbo.2121110054_ProductImage", name: "Product_Id1", newName: "Product_Id");
            //AlterColumn("dbo.2121110054_ProductImage", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_ProductImage", "Product_Id1", c => c.Int());
            //CreateIndex("dbo.2121110054_ProductImage", "Product_Id1");
        }
        
        public override void Down()
        {
            DropIndex("dbo.2121110054_ProductImage", new[] { "Product_Id" });
            AlterColumn("dbo.2121110054_ProductImage", "Product_Id1", c => c.Int());
            AlterColumn("dbo.2121110054_ProductImage", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.2121110054_ProductImage", name: "Product_Id", newName: "Product_Id1");
            AddColumn("dbo.2121110054_ProductImage", "Product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.2121110054_ProductImage", "Product_Id1");
        }
    }
}
