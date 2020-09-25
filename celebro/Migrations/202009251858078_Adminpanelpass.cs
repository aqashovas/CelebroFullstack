namespace celebro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adminpanelpass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Username", c => c.String());
            AddColumn("dbo.Admins", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Admins", "Username");
        }
    }
}
