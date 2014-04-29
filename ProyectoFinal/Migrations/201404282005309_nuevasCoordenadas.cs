namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevasCoordenadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modelo_Coordenadas", "latitudUno", c => c.String());
            AddColumn("dbo.Modelo_Coordenadas", "longitudUno", c => c.String());
            AddColumn("dbo.Modelo_Coordenadas", "latitudDos", c => c.String());
            AddColumn("dbo.Modelo_Coordenadas", "longitudDos", c => c.String());
            AddColumn("dbo.Modelo_Coordenadas", "latitudTres", c => c.String());
            AddColumn("dbo.Modelo_Coordenadas", "longitudTres", c => c.String());
            DropColumn("dbo.Modelo_Coordenadas", "latitud");
            DropColumn("dbo.Modelo_Coordenadas", "longitud");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modelo_Coordenadas", "longitud", c => c.String());
            AddColumn("dbo.Modelo_Coordenadas", "latitud", c => c.String());
            DropColumn("dbo.Modelo_Coordenadas", "longitudTres");
            DropColumn("dbo.Modelo_Coordenadas", "latitudTres");
            DropColumn("dbo.Modelo_Coordenadas", "longitudDos");
            DropColumn("dbo.Modelo_Coordenadas", "latitudDos");
            DropColumn("dbo.Modelo_Coordenadas", "longitudUno");
            DropColumn("dbo.Modelo_Coordenadas", "latitudUno");
        }
    }
}
