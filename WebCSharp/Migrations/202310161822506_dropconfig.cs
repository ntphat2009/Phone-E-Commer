﻿namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropconfig : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.2121110054_Config");
        }
        
        public override void Down()
        {
        }
    }
}
