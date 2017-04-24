namespace RouteBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Postojka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Postojkis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Adresa = c.String(),
                        Lokacija = c.String(),
                        gMapsCoords = c.String(nullable: false),
                        PrevoznikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prevozniks", t => t.PrevoznikId, cascadeDelete: true)
                .Index(t => t.PrevoznikId);
            
            CreateTable(
                "dbo.Prevozniks",
                c => new
                    {
                        PrevoznikId = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Linii = c.String(),
                    })
                .PrimaryKey(t => t.PrevoznikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postojkis", "PrevoznikId", "dbo.Prevozniks");
            DropIndex("dbo.Postojkis", new[] { "PrevoznikId" });
            DropTable("dbo.uAccounts");
            DropTable("dbo.Prevozniks");
            DropTable("dbo.Postojkis");
        }
    }
}
