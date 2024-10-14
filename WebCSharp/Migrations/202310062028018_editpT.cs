namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editpT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.2121110054_Post", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.2121110054_Topic", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.2121110054_Topic", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_Post", "Status", c => c.Int(nullable: false));
        }
    }
}
