namespace celebro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suggestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Mail = c.String(),
                        Phone = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suggestions");
        }
    }
}
