namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.2121110054_Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Slug = c.String(nullable: false),
                        Image = c.String(),
                        Sort_Order = c.Int(nullable: false),
                        Metakey = c.String(nullable: false),
                        Metadesc = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.2121110054_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                        Name = c.String(),
                        Slug = c.String(),
                        Image = c.String(),
                        Price = c.Double(nullable: false),
                        Price_Sale = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        Detail = c.String(),
                        Sort_Order = c.Int(nullable: false),
                        Metakey = c.String(),
                        Metadesc = c.String(),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Brands_Id = c.Int(),
                        Products_Id = c.Int(),
                        Category_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Brand", t => t.Brands_Id)
                .ForeignKey("dbo.2121110054_Product", t => t.Products_Id)
                .ForeignKey("dbo.2121110054_Category", t => t.Category_Id1)
                .Index(t => t.Brands_Id)
                .Index(t => t.Products_Id)
                .Index(t => t.Category_Id1);
            
            CreateTable(
                "dbo.2121110054_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Slug = c.String(nullable: false, maxLength: 150),
                        Image = c.String(),
                        Sort_Order = c.Int(nullable: false),
                        Metakey = c.String(nullable: false),
                        Metadesc = c.String(nullable: false),
                        Parent_Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.2121110054_Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Replay_id = c.Int(nullable: false),
                        Sort_Order = c.Int(nullable: false),
                        Metakey = c.String(),
                        Metadesc = c.String(),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.2121110054_Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Link = c.String(nullable: false),
                        Position = c.String(),
                        Parent_Id = c.Int(nullable: false),
                        Table_Id = c.Int(nullable: false),
                        Type = c.String(),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.2121110054_OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        Order_Id1 = c.Int(),
                        Product_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.2121110054_Order", t => t.Order_Id1)
                .ForeignKey("dbo.2121110054_Product", t => t.Product_Id1)
                .Index(t => t.Order_Id1)
                .Index(t => t.Product_Id1);
            
            CreateTable(
                "dbo.2121110054_Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Note = c.String(),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.2121110054_Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Link = c.String(nullable: false),
                        Image = c.String(),
                        Position = c.String(),
                        Sort_Order = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.2121110054_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(),
                        Role = c.String(),
                        Status = c.Int(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.2121110054_OrderDetail", "Product_Id1", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_OrderDetail", "Order_Id1", "dbo.2121110054_Order");
            DropForeignKey("dbo.2121110054_Product", "Category_Id1", "dbo.2121110054_Category");
            DropForeignKey("dbo.2121110054_Post", "Categorys_Id", "dbo.2121110054_Category");
            DropForeignKey("dbo.2121110054_Product", "Products_Id", "dbo.2121110054_Product");
            DropForeignKey("dbo.2121110054_Product", "Brands_Id", "dbo.2121110054_Brand");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.2121110054_OrderDetail", new[] { "Product_Id1" });
            DropIndex("dbo.2121110054_OrderDetail", new[] { "Order_Id1" });
            DropIndex("dbo.2121110054_Post", new[] { "Categorys_Id" });
            DropIndex("dbo.2121110054_Product", new[] { "Category_Id1" });
            DropIndex("dbo.2121110054_Product", new[] { "Products_Id" });
            DropIndex("dbo.2121110054_Product", new[] { "Brands_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.2121110054_User");
            DropTable("dbo.2121110054_Topic");
            DropTable("dbo.2121110054_Slider");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.2121110054_Order");
            DropTable("dbo.2121110054_OrderDetail");
            DropTable("dbo.2121110054_Menu");
            DropTable("dbo.2121110054_Link");
            DropTable("dbo.2121110054_Contact");
            DropTable("dbo.2121110054_Post");
            DropTable("dbo.2121110054_Category");
            DropTable("dbo.2121110054_Product");
            DropTable("dbo.2121110054_Brand");
        }
    }
}
