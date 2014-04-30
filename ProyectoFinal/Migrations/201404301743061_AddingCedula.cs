namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCedula : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modelo_Datos", "Cedula", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modelo_Datos", "Cedula");
        }
    }
}
