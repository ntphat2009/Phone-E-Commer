namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesale2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.2121110054_ProductSale", "DiscountPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_ProductSale", "DiscountPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
