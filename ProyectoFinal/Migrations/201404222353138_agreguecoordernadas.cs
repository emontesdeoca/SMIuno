namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreguecoordernadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modelo_Coordenadas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        latitud = c.String(),
                        longitud = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.RootObjects", "modeloCoordenadas_id", c => c.Int());
            AddForeignKey("dbo.RootObjects", "modeloCoordenadas_id", "dbo.Modelo_Coordenadas", "id");
            CreateIndex("dbo.RootObjects", "modeloCoordenadas_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadas_id" });
            DropForeignKey("dbo.RootObjects", "modeloCoordenadas_id", "dbo.Modelo_Coordenadas");
            DropColumn("dbo.RootObjects", "modeloCoordenadas_id");
            DropTable("dbo.Modelo_Coordenadas");
        }
    }
}
