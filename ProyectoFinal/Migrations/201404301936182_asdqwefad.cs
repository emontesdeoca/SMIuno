namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdqwefad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientModels", "Apellido", c => c.String(maxLength: 60));
            AlterColumn("dbo.PatientModels", "Cedula", c => c.String(maxLength: 11));
            AlterColumn("dbo.PatientModels", "Religion", c => c.String());
            AlterColumn("dbo.PatientModels", "CreadoPor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientModels", "CreadoPor", c => c.String(nullable: false));
            AlterColumn("dbo.PatientModels", "Religion", c => c.String(nullable: false));
            AlterColumn("dbo.PatientModels", "Cedula", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.PatientModels", "Apellido", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
