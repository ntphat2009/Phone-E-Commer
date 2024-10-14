namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.2121110054_Post", name: "Categorys_Id", newName: "Category_Id");
            RenameIndex(table: "dbo.2121110054_Post", name: "IX_Categorys_Id", newName: "IX_Category_Id");
            AddColumn("dbo.2121110054_Post", "Topics_Id", c => c.Int());
            CreateIndex("dbo.2121110054_Post", "Topics_Id");
            AddForeignKey("dbo.2121110054_Post", "Topics_Id", "dbo.2121110054_Topic", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.2121110054_Post", "Topics_Id", "dbo.2121110054_Topic");
            DropIndex("dbo.2121110054_Post", new[] { "Topics_Id" });
            DropColumn("dbo.2121110054_Post", "Topics_Id");
            RenameIndex(table: "dbo.2121110054_Post", name: "IX_Category_Id", newName: "IX_Categorys_Id");
            RenameColumn(table: "dbo.2121110054_Post", name: "Category_Id", newName: "Categorys_Id");
        }
    }
}
