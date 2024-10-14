namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.2121110054_Product", "isHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.2121110054_Product", "isHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.2121110054_Product", "isSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.2121110054_Product", "isFeature", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.2121110054_Product", "Price_Sale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.2121110054_Category", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_Category", "Slug", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Product", "Price_Sale", c => c.Double(nullable: false));
            AlterColumn("dbo.2121110054_Product", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.2121110054_Product", "isFeature");
            DropColumn("dbo.2121110054_Product", "isSale");
            DropColumn("dbo.2121110054_Product", "isHome");
            DropColumn("dbo.2121110054_Product", "isHot");
        }
    }
}
