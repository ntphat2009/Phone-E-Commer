namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.2121110054_Product", name: "Category_Id1", newName: "Categorys_Id");
            RenameIndex(table: "dbo.2121110054_Product", name: "IX_Category_Id1", newName: "IX_Categorys_Id");
            AlterColumn("dbo.2121110054_Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Contact", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Contact", "Email", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Contact", "Phone", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.2121110054_Menu", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Menu", "Link", c => c.String());
            AlterColumn("dbo.2121110054_Order", "Email", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Order", "Phone", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Order", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Slider", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Slider", "Link", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Slider", "Image", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_User", "Email", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_User", "Phone", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_User", "UserName", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_User", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_User", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Slider", "Image", c => c.String());
            AlterColumn("dbo.2121110054_Slider", "Link", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Slider", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Order", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Order", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Order", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Menu", "Link", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Menu", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Contact", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Contact", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Contact", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Post", "Title", c => c.String());
            AlterColumn("dbo.2121110054_Product", "Name", c => c.String());
            RenameIndex(table: "dbo.2121110054_Product", name: "IX_Categorys_Id", newName: "IX_Category_Id1");
            RenameColumn(table: "dbo.2121110054_Product", name: "Categorys_Id", newName: "Category_Id1");
        }
    }
}
