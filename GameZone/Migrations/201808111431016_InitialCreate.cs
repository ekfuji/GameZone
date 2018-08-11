namespace GameZone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaixaEtaria",
                c => new
                    {
                        FaixaEtariaId = c.Int(nullable: false, identity: true),
                        TipoDeClassificacao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.FaixaEtariaId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 100),
                        AnoEdicao = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GeneroId = c.Int(nullable: false),
                        PlataformaId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        FaixaEtariaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.FaixaEtaria", t => t.FaixaEtariaId, cascadeDelete: true)
                .ForeignKey("dbo.Genero", t => t.GeneroId, cascadeDelete: true)
                .ForeignKey("dbo.Plataforma", t => t.PlataformaId, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.GeneroId)
                .Index(t => t.PlataformaId)
                .Index(t => t.PublisherId)
                .Index(t => t.FaixaEtariaId);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        PlataformaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PlataformaId);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.Game", "PlataformaId", "dbo.Plataforma");
            DropForeignKey("dbo.Game", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.Game", "FaixaEtariaId", "dbo.FaixaEtaria");
            DropIndex("dbo.Game", new[] { "FaixaEtariaId" });
            DropIndex("dbo.Game", new[] { "PublisherId" });
            DropIndex("dbo.Game", new[] { "PlataformaId" });
            DropIndex("dbo.Game", new[] { "GeneroId" });
            DropTable("dbo.Publisher");
            DropTable("dbo.Plataforma");
            DropTable("dbo.Genero");
            DropTable("dbo.Game");
            DropTable("dbo.FaixaEtaria");
        }
    }
}
