namespace InForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aggiunzione",
                c => new
                    {
                        IdAggiunzione = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Prezzo = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.IdAggiunzione);
            
            CreateTable(
                "dbo.DettaglioOrdine",
                c => new
                    {
                        IdDettaglioOrdine = c.Int(nullable: false, identity: true),
                        Quantita = c.Int(nullable: false),
                        IdAggiunzione = c.Int(),
                        IdProdotto = c.Int(nullable: false),
                        IdOrdine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDettaglioOrdine)
                .ForeignKey("dbo.Aggiunzione", t => t.IdAggiunzione)
                .ForeignKey("dbo.Ordine", t => t.IdOrdine)
                .ForeignKey("dbo.Prodotto", t => t.IdProdotto)
                .Index(t => t.IdAggiunzione)
                .Index(t => t.IdProdotto)
                .Index(t => t.IdOrdine);
            
            CreateTable(
                "dbo.Ordine",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        Evaso = c.Boolean(nullable: false),
                        Concluso = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        TempoConsegna = c.String(nullable: false, maxLength: 50),
                        Commento = c.String(nullable: false),
                        Indirizzo = c.String(),
                        Importo = c.Decimal(nullable: false, storeType: "money"),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.User", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Ruolo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Prodotto",
                c => new
                    {
                        IdProdotto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Foto = c.String(nullable: false),
                        Prezzo = c.Decimal(nullable: false, storeType: "money"),
                        Ingredienti = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdProdotto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdine", "IdProdotto", "dbo.Prodotto");
            DropForeignKey("dbo.Ordine", "IdUser", "dbo.User");
            DropForeignKey("dbo.DettaglioOrdine", "IdOrdine", "dbo.Ordine");
            DropForeignKey("dbo.DettaglioOrdine", "IdAggiunzione", "dbo.Aggiunzione");
            DropIndex("dbo.Ordine", new[] { "IdUser" });
            DropIndex("dbo.DettaglioOrdine", new[] { "IdOrdine" });
            DropIndex("dbo.DettaglioOrdine", new[] { "IdProdotto" });
            DropIndex("dbo.DettaglioOrdine", new[] { "IdAggiunzione" });
            DropTable("dbo.Prodotto");
            DropTable("dbo.User");
            DropTable("dbo.Ordine");
            DropTable("dbo.DettaglioOrdine");
            DropTable("dbo.Aggiunzione");
        }
    }
}
