namespace InForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRequiredRole : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Ruolo", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Ruolo", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
