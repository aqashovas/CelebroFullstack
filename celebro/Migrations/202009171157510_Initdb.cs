namespace celebro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Celebrities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Price = c.Int(nullable: false),
                        Mail = c.String(),
                        Phone = c.String(),
                        Socialmedia = c.String(),
                        Photo = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToWhom = c.String(),
                        FromWhom = c.String(),
                        Videotitle = c.String(),
                        Videotext = c.String(),
                        Phone = c.String(),
                        Mail = c.String(),
                        Celebrity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celebrities", t => t.Celebrity_Id)
                .Index(t => t.Celebrity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Celebrity_Id", "dbo.Celebrities");
            DropForeignKey("dbo.Celebrities", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "Celebrity_Id" });
            DropIndex("dbo.Celebrities", new[] { "Category_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Celebrities");
            DropTable("dbo.Categories");
        }
    }
}
