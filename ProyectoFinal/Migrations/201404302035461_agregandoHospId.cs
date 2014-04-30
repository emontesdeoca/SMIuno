namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoHospId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RootObjects", "HospId", c => c.Int(nullable: false));
            AddColumn("dbo.Modelo_CoordenadasUno", "HospId", c => c.Int(nullable: false));
            AddColumn("dbo.Modelo_CoordenadasDos", "HospId", c => c.Int(nullable: false));
            AddColumn("dbo.Modelo_CoordenadasTres", "HospId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modelo_CoordenadasTres", "HospId");
            DropColumn("dbo.Modelo_CoordenadasDos", "HospId");
            DropColumn("dbo.Modelo_CoordenadasUno", "HospId");
            DropColumn("dbo.RootObjects", "HospId");
        }
    }
}
