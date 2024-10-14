namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBrand : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.2121110054_Brand", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_Brand", "Slug", c => c.String(nullable: false));
        }
    }
}
