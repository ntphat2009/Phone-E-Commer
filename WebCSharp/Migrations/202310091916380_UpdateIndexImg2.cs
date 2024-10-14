namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIndexImg2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.2121110054_ProductImage", "Product_Id1");
        }
        
        public override void Down()
        {
        }
    }
}
