namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_OrderDetail", "Product_Id1", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_OrderDetail", "Order_Id1", "dbo.2121110054_Order");
            DropIndex("dbo.2121110054_OrderDetail", new[] { "Order_Id1" });
            DropIndex("dbo.2121110054_OrderDetail", new[] { "Product_Id1" });
            RenameColumn(table: "dbo.2121110054_OrderDetail", name: "Product_Id1", newName: "ProductId");
            RenameColumn(table: "dbo.2121110054_OrderDetail", name: "Order_Id1", newName: "OrderId");
            AddColumn("dbo.2121110054_Order", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_OrderDetail", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.2121110054_OrderDetail", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.2121110054_OrderDetail", "OrderId");
            CreateIndex("dbo.2121110054_OrderDetail", "ProductId");
            CreateIndex("dbo.2121110054_Order", "UserId");
            AddForeignKey("dbo.2121110054_Order", "UserId", "dbo.2121110054_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.2121110054_OrderDetail", "ProductId", "dbo.2121110054_Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.2121110054_OrderDetail", "OrderId", "dbo.2121110054_Order", "Id", cascadeDelete: true);
            DropColumn("dbo.2121110054_OrderDetail", "Order_Id");
            DropColumn("dbo.2121110054_OrderDetail", "Product_Id");
            DropColumn("dbo.2121110054_Order", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.2121110054_Order", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.2121110054_OrderDetail", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.2121110054_OrderDetail", "Order_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.2121110054_OrderDetail", "OrderId", "dbo.2121110054_Order");
            DropForeignKey("dbo.2121110054_OrderDetail", "ProductId", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_Order", "UserId", "dbo.2121110054_User");
            DropIndex("dbo.2121110054_Order", new[] { "UserId" });
            DropIndex("dbo.2121110054_OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.2121110054_OrderDetail", new[] { "OrderId" });
            AlterColumn("dbo.2121110054_OrderDetail", "ProductId", c => c.Int());
            AlterColumn("dbo.2121110054_OrderDetail", "OrderId", c => c.Int());
            DropColumn("dbo.2121110054_Order", "UserId");
            RenameColumn(table: "dbo.2121110054_OrderDetail", name: "OrderId", newName: "Order_Id1");
            RenameColumn(table: "dbo.2121110054_OrderDetail", name: "ProductId", newName: "Product_Id1");
            CreateIndex("dbo.2121110054_OrderDetail", "Product_Id1");
            CreateIndex("dbo.2121110054_OrderDetail", "Order_Id1");
            AddForeignKey("dbo.2121110054_OrderDetail", "Order_Id1", "dbo.2121110054_Order", "Id");
            AddForeignKey("dbo.2121110054_OrderDetail", "Product_Id1", "dbo.2121110054_Product", "Id");
        }
    }
}
