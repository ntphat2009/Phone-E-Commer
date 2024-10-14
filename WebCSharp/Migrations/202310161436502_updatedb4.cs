namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.2121110054_Config",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Author = c.String(nullable: false, maxLength: 150),  
                   Email = c.String(nullable: false, maxLength: 150),
                   Phone = c.String(nullable: false, maxLength: 150),
                   Zalo = c.String(nullable: false, maxLength: 150),
                   Facebook = c.String(nullable: false, maxLength: 150),
                   Address = c.String(nullable: false, maxLength: 150),
                   YouTube = c.String(nullable: false, maxLength: 150),
                   Create_By = c.Int(nullable: false),
                   Update_By = c.Int(nullable: false),
                   Create_at = c.DateTime(nullable: false),
                   Update_at = c.DateTime(nullable: false),
                   Metakey = c.String(nullable: false),
                   Metadesc = c.String(nullable: false),
                   Status = c.Boolean(nullable: false),
               })
               .PrimaryKey(t => t.Id);
            DropTable("dbo.2121110054_Link");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.2121110054_Link",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Table_Id = c.Int(nullable: false),
                        Slug = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
