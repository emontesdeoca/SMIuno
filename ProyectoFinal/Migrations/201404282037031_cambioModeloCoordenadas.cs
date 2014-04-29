namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioModeloCoordenadas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RootObjects", "modeloCoordenadas_id", "dbo.Modelo_Coordenadas");
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadas_id" });
            CreateTable(
                "dbo.Modelo_CoordenadasUno",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        latitudUno = c.String(),
                        longitudUno = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modelo_CoordenadasDos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        latitudDos = c.String(),
                        longitudDos = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modelo_CoordenadasTres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        latitudTres = c.String(),
                        longitudTres = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.RootObjects", "modeloCoordenadasUno_id", c => c.Int());
            AddColumn("dbo.RootObjects", "modeloCoordenadasDos_id", c => c.Int());
            AddColumn("dbo.RootObjects", "modeloCoordenadasTres_id", c => c.Int());
            AddForeignKey("dbo.RootObjects", "modeloCoordenadasUno_id", "dbo.Modelo_CoordenadasUno", "id");
            AddForeignKey("dbo.RootObjects", "modeloCoordenadasDos_id", "dbo.Modelo_CoordenadasDos", "id");
            AddForeignKey("dbo.RootObjects", "modeloCoordenadasTres_id", "dbo.Modelo_CoordenadasTres", "id");
            CreateIndex("dbo.RootObjects", "modeloCoordenadasUno_id");
            CreateIndex("dbo.RootObjects", "modeloCoordenadasDos_id");
            CreateIndex("dbo.RootObjects", "modeloCoordenadasTres_id");
            DropColumn("dbo.RootObjects", "modeloCoordenadas_id");
            DropTable("dbo.Modelo_Coordenadas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Modelo_Coordenadas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        latitudUno = c.String(),
                        longitudUno = c.String(),
                        latitudDos = c.String(),
                        longitudDos = c.String(),
                        latitudTres = c.String(),
                        longitudTres = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.RootObjects", "modeloCoordenadas_id", c => c.Int());
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadasTres_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadasDos_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadasUno_id" });
            DropForeignKey("dbo.RootObjects", "modeloCoordenadasTres_id", "dbo.Modelo_CoordenadasTres");
            DropForeignKey("dbo.RootObjects", "modeloCoordenadasDos_id", "dbo.Modelo_CoordenadasDos");
            DropForeignKey("dbo.RootObjects", "modeloCoordenadasUno_id", "dbo.Modelo_CoordenadasUno");
            DropColumn("dbo.RootObjects", "modeloCoordenadasTres_id");
            DropColumn("dbo.RootObjects", "modeloCoordenadasDos_id");
            DropColumn("dbo.RootObjects", "modeloCoordenadasUno_id");
            DropTable("dbo.Modelo_CoordenadasTres");
            DropTable("dbo.Modelo_CoordenadasDos");
            DropTable("dbo.Modelo_CoordenadasUno");
            CreateIndex("dbo.RootObjects", "modeloCoordenadas_id");
            AddForeignKey("dbo.RootObjects", "modeloCoordenadas_id", "dbo.Modelo_Coordenadas", "id");
        }
    }
}
