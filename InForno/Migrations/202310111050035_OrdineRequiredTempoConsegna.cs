﻿namespace InForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdineRequiredTempoConsegna : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ordine", "TempoConsegna", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ordine", "TempoConsegna", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
