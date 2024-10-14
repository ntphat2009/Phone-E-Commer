namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_Post",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Topic_Id = c.Int(nullable: false),
                    Title = c.String(),
                    Slug = c.String(),
                    Detail = c.String(),
                    Image = c.String(),
                    Type = c.String(),
                    Metakey = c.String(),
                    Metadesc = c.String(),
                    Status = c.Int(nullable: false),
                    Create_By = c.Int(nullable: false),
                    Update_By = c.Int(nullable: false),
                    Create_at = c.DateTime(nullable: false),
                    Update_at = c.DateTime(nullable: false),
                    Categorys_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Category", t => t.Categorys_Id)
                .Index(t => t.Categorys_Id);

            CreateTable(
                "dbo.2121110054_Topic",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Slug = c.String(nullable: false),
                    Parent_Id = c.Int(nullable: false),
                    Metakey = c.String(),
                    Metadesc = c.String(),
                    Status = c.Int(nullable: false),
                    Create_By = c.Int(nullable: false),
                    Update_By = c.Int(nullable: false),
                    Create_at = c.DateTime(nullable: false),
                    Update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_Post", "Categorys_Id", "dbo.2121110054_Category");
            DropIndex("dbo.2121110054_Post", new[] { "Categorys_Id" });
            DropTable("dbo.2121110054_Post");
            DropTable("dbo.2121110054_Topic");
        }
    }
}
