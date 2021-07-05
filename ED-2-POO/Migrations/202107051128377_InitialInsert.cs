namespace ED_2_POO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialInsert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carteiras",
                c => new
                    {
                        CarteiraID = c.Int(nullable: false, identity: true),
                        Endereco = c.String(),
                        Cliente_ClienteID = c.Int(),
                        Corretora_CorretoraID = c.Int(),
                    })
                .PrimaryKey(t => t.CarteiraID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .ForeignKey("dbo.Corretoras", t => t.Corretora_CorretoraID)
                .Index(t => t.Cliente_ClienteID)
                .Index(t => t.Corretora_CorretoraID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Celular = c.String(),
                        PassHash = c.String(),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Corretoras",
                c => new
                    {
                        CorretoraID = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CorretoraID);
            
            CreateTable(
                "dbo.ItemCarteiras",
                c => new
                    {
                        ItemCarteiraID = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        Carteira_CarteiraID = c.Int(),
                        Moeda_MoedaID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemCarteiraID)
                .ForeignKey("dbo.Carteiras", t => t.Carteira_CarteiraID)
                .ForeignKey("dbo.Moedas", t => t.Moeda_MoedaID)
                .Index(t => t.Carteira_CarteiraID)
                .Index(t => t.Moeda_MoedaID);
            
            CreateTable(
                "dbo.Moedas",
                c => new
                    {
                        MoedaID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.MoedaID);
            
            CreateTable(
                "dbo.ParMoedas",
                c => new
                    {
                        ParMoedaID = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        MoedaBase_MoedaID = c.Int(),
                        MoedaCotacao_MoedaID = c.Int(),
                    })
                .PrimaryKey(t => t.ParMoedaID)
                .ForeignKey("dbo.Moedas", t => t.MoedaBase_MoedaID)
                .ForeignKey("dbo.Moedas", t => t.MoedaCotacao_MoedaID)
                .Index(t => t.MoedaBase_MoedaID)
                .Index(t => t.MoedaCotacao_MoedaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParMoedas", "MoedaCotacao_MoedaID", "dbo.Moedas");
            DropForeignKey("dbo.ParMoedas", "MoedaBase_MoedaID", "dbo.Moedas");
            DropForeignKey("dbo.ItemCarteiras", "Moeda_MoedaID", "dbo.Moedas");
            DropForeignKey("dbo.ItemCarteiras", "Carteira_CarteiraID", "dbo.Carteiras");
            DropForeignKey("dbo.Carteiras", "Corretora_CorretoraID", "dbo.Corretoras");
            DropForeignKey("dbo.Carteiras", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.ParMoedas", new[] { "MoedaCotacao_MoedaID" });
            DropIndex("dbo.ParMoedas", new[] { "MoedaBase_MoedaID" });
            DropIndex("dbo.ItemCarteiras", new[] { "Moeda_MoedaID" });
            DropIndex("dbo.ItemCarteiras", new[] { "Carteira_CarteiraID" });
            DropIndex("dbo.Carteiras", new[] { "Corretora_CorretoraID" });
            DropIndex("dbo.Carteiras", new[] { "Cliente_ClienteID" });
            DropTable("dbo.ParMoedas");
            DropTable("dbo.Moedas");
            DropTable("dbo.ItemCarteiras");
            DropTable("dbo.Corretoras");
            DropTable("dbo.Clientes");
            DropTable("dbo.Carteiras");
        }
    }
}
