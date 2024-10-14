namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.2121110054_Brand", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Product", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Category", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Post", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Topic", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Contact", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Menu", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_OrderDetail", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Order", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Slider", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_User", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_User", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Slider", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Order", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_OrderDetail", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Menu", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Contact", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Topic", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Post", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Category", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Product", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Brand", "Status", c => c.Int(nullable: false));
        }
    }
}
