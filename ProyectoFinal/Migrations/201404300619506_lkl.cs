namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lkl : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.RootObjects", "modeloTrauma_id", c => c.Int());
            CreateIndex("dbo.RootObjects", "modeloTrauma_id");
            AddForeignKey("dbo.RootObjects", "modeloTrauma_id", "dbo.Modelo_Trauma", "id");
        }
    }
}
