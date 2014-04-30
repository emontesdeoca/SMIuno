namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowingMultipleModeloTrauma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RootObjects", "modeloTrauma_id", "dbo.Modelo_Trauma");
            DropIndex("dbo.RootObjects", new[] { "modeloTrauma_id" });
            DropColumn("dbo.RootObjects", "modeloTrauma_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RootObjects", "modeloTrauma_id", c => c.Int());
            CreateIndex("dbo.RootObjects", "modeloTrauma_id");
            AddForeignKey("dbo.RootObjects", "modeloTrauma_id", "dbo.Modelo_Trauma", "id");
        }
    }
}
