namespace celebro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Celebrities", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Orders", "Celebrity_Id", "dbo.Celebrities");
            DropIndex("dbo.Celebrities", new[] { "Category_Id" });
            DropIndex("dbo.Orders", new[] { "Celebrity_Id" });
            RenameColumn(table: "dbo.Celebrities", name: "Category_Id", newName: "CategoryID");
            RenameColumn(table: "dbo.Orders", name: "Celebrity_Id", newName: "CelebrityID");
            AlterColumn("dbo.Celebrities", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CelebrityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Celebrities", "CategoryID");
            CreateIndex("dbo.Orders", "CelebrityID");
            AddForeignKey("dbo.Celebrities", "CategoryID", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CelebrityID", "dbo.Celebrities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CelebrityID", "dbo.Celebrities");
            DropForeignKey("dbo.Celebrities", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "CelebrityID" });
            DropIndex("dbo.Celebrities", new[] { "CategoryID" });
            AlterColumn("dbo.Orders", "CelebrityID", c => c.Int());
            AlterColumn("dbo.Celebrities", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "CelebrityID", newName: "Celebrity_Id");
            RenameColumn(table: "dbo.Celebrities", name: "CategoryID", newName: "Category_Id");
            CreateIndex("dbo.Orders", "Celebrity_Id");
            CreateIndex("dbo.Celebrities", "Category_Id");
            AddForeignKey("dbo.Orders", "Celebrity_Id", "dbo.Celebrities", "Id");
            AddForeignKey("dbo.Celebrities", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
