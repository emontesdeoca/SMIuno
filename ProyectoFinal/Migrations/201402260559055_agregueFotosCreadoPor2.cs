namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregueFotosCreadoPor2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Upload_Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        CreadoPor = c.String(nullable: false),
                        PatientModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientModels", t => t.PatientModelId, cascadeDelete: true)
                .Index(t => t.PatientModelId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Upload_Photos", new[] { "PatientModelId" });
            DropForeignKey("dbo.Upload_Photos", "PatientModelId", "dbo.PatientModels");
            DropTable("dbo.Upload_Photos");
        }
    }
}
