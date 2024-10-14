namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.2121110054_Product", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Product", "Metakey", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Product", "Metadesc", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Topic", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Topic", "Slug", c => c.String());
            AlterColumn("dbo.2121110054_Topic", "Metakey", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.2121110054_Topic", "Metadesc", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_Topic", "Metadesc", c => c.String());
            AlterColumn("dbo.2121110054_Topic", "Metakey", c => c.String());
            AlterColumn("dbo.2121110054_Topic", "Slug", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Topic", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.2121110054_Product", "Metadesc", c => c.String());
            AlterColumn("dbo.2121110054_Product", "Metakey", c => c.String());
            AlterColumn("dbo.2121110054_Product", "Name", c => c.String(nullable: false));
        }
    }
}
