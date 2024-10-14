namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_Config",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 150),
                        Zalo = c.String(maxLength: 150),
                        Facebook = c.String(maxLength: 150),
                        Address = c.String(maxLength: 150),
                        Youtube = c.String(maxLength: 150),
                        Metakey = c.String(nullable: false, maxLength: 150),
                        Metadesc = c.String(nullable: false, maxLength: 150),
                        Status = c.Boolean(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.2121110054_Config");
        }
    }
}
