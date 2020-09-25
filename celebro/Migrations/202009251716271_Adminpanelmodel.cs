namespace celebro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adminpanelmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admincats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        AdminCatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admincats", t => t.AdminCatId, cascadeDelete: true)
                .Index(t => t.AdminCatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "AdminCatId", "dbo.Admincats");
            DropIndex("dbo.Admins", new[] { "AdminCatId" });
            DropTable("dbo.Admins");
            DropTable("dbo.Admincats");
        }
    }
}
