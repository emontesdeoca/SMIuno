namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Apellido = c.String(nullable: false, maxLength: 60),
                        Cedula = c.String(nullable: false, maxLength: 11),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        Sexo = c.String(),
                        TipoSangre = c.String(),
                        SeguroMedico = c.String(),
                        NumeroSeguroMedico = c.String(),
                        NumeroSeguroSocial = c.String(),
                        Religion = c.String(nullable: false),
                        CreadoPor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Form_Blood_Pressure",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Sistolica = c.Int(nullable: false),
                        Diastolica = c.Int(nullable: false),
                        RitmoCardiaco = c.Int(nullable: false),
                        CreadoPor = c.String(nullable: false),
                        PatientModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientModels", t => t.PatientModelId, cascadeDelete: true)
                .Index(t => t.PatientModelId);
            
            CreateTable(
                "dbo.Form_Vital_Signs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Peso = c.Double(nullable: false),
                        Temperatura = c.Double(nullable: false),
                        Pulso = c.Int(nullable: false),
                        PresionSanguinea = c.String(nullable: false),
                        Respiracion = c.Int(nullable: false),
                        Dolor = c.String(nullable: false),
                        CreadoPor = c.String(nullable: false),
                        PatientModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientModels", t => t.PatientModelId, cascadeDelete: true)
                .Index(t => t.PatientModelId);
            
            CreateTable(
                "dbo.Form_Vaccinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vacuna = c.String(nullable: false),
                        OtraVacuna = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaSiguiente = c.DateTime(nullable: false),
                        CreadoPor = c.String(nullable: false),
                        PatientModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientModels", t => t.PatientModelId, cascadeDelete: true)
                .Index(t => t.PatientModelId);
            
            CreateTable(
                "dbo.RootObjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        modeloDatos_id = c.Int(),
                        modeloExamen_id = c.Int(),
                        modeloMotivos_id = c.Int(),
                        modeloCoordenadasUno_id = c.Int(),
                        modeloCoordenadasDos_id = c.Int(),
                        modeloCoordenadasTres_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Modelo_Datos", t => t.modeloDatos_id)
                .ForeignKey("dbo.Modelo_Examen", t => t.modeloExamen_id)
                .ForeignKey("dbo.Modelo_Motivos", t => t.modeloMotivos_id)
                .ForeignKey("dbo.Modelo_CoordenadasUno", t => t.modeloCoordenadasUno_id)
                .ForeignKey("dbo.Modelo_CoordenadasDos", t => t.modeloCoordenadasDos_id)
                .ForeignKey("dbo.Modelo_CoordenadasTres", t => t.modeloCoordenadasTres_id)
                .Index(t => t.modeloDatos_id)
                .Index(t => t.modeloExamen_id)
                .Index(t => t.modeloMotivos_id)
                .Index(t => t.modeloCoordenadasUno_id)
                .Index(t => t.modeloCoordenadasDos_id)
                .Index(t => t.modeloCoordenadasTres_id);
            
            CreateTable(
                "dbo.Modelo_Datos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Edad = c.String(),
                        NombrePaciente = c.String(),
                        NombreResponsable = c.String(),
                        NumeroContacto = c.String(),
                        SeguroMedico = c.String(),
                        Sexo = c.String(),
                        Fecha_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Fechas", t => t.Fecha_id)
                .Index(t => t.Fecha_id);
            
            CreateTable(
                "dbo.Fechas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        year = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        dayOfMonth = c.Int(nullable: false),
                        hourOfDay = c.Int(nullable: false),
                        minute = c.Int(nullable: false),
                        second = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modelo_Examen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Abdomen = c.String(),
                        ApCardio = c.String(),
                        ApRespiratorio = c.String(),
                        Fc = c.String(),
                        Fr = c.String(),
                        Gasgow = c.String(),
                        Genitourinatorio = c.String(),
                        SistemaNervioso = c.String(),
                        Ta = c.String(),
                        Taxilar = c.String(),
                        Trectal = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modelo_Motivos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Alergias = c.String(),
                        EnfermedadesPrevias = c.String(),
                        InicioSintomas = c.String(),
                        Medicacion = c.String(),
                        MotivoConsulta = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modelo_Trauma",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nivel = c.String(),
                        Posicion = c.String(),
                        RootObjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RootObjects", t => t.RootObjectId, cascadeDelete: true)
                .Index(t => t.RootObjectId);
            
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
            DropIndex("dbo.Modelo_Trauma", new[] { "RootObjectId" });
            DropIndex("dbo.Modelo_Datos", new[] { "Fecha_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadasTres_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadasDos_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloCoordenadasUno_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloMotivos_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloExamen_id" });
            DropIndex("dbo.RootObjects", new[] { "modeloDatos_id" });
            DropIndex("dbo.Form_Vaccinations", new[] { "PatientModelId" });
            DropIndex("dbo.Form_Vital_Signs", new[] { "PatientModelId" });
            DropIndex("dbo.Form_Blood_Pressure", new[] { "PatientModelId" });
            DropForeignKey("dbo.Upload_Photos", "PatientModelId", "dbo.PatientModels");
            DropForeignKey("dbo.Modelo_Trauma", "RootObjectId", "dbo.RootObjects");
            DropForeignKey("dbo.Modelo_Datos", "Fecha_id", "dbo.Fechas");
            DropForeignKey("dbo.RootObjects", "modeloCoordenadasTres_id", "dbo.Modelo_CoordenadasTres");
            DropForeignKey("dbo.RootObjects", "modeloCoordenadasDos_id", "dbo.Modelo_CoordenadasDos");
            DropForeignKey("dbo.RootObjects", "modeloCoordenadasUno_id", "dbo.Modelo_CoordenadasUno");
            DropForeignKey("dbo.RootObjects", "modeloMotivos_id", "dbo.Modelo_Motivos");
            DropForeignKey("dbo.RootObjects", "modeloExamen_id", "dbo.Modelo_Examen");
            DropForeignKey("dbo.RootObjects", "modeloDatos_id", "dbo.Modelo_Datos");
            DropForeignKey("dbo.Form_Vaccinations", "PatientModelId", "dbo.PatientModels");
            DropForeignKey("dbo.Form_Vital_Signs", "PatientModelId", "dbo.PatientModels");
            DropForeignKey("dbo.Form_Blood_Pressure", "PatientModelId", "dbo.PatientModels");
            DropTable("dbo.Upload_Photos");
            DropTable("dbo.Modelo_CoordenadasTres");
            DropTable("dbo.Modelo_CoordenadasDos");
            DropTable("dbo.Modelo_CoordenadasUno");
            DropTable("dbo.Modelo_Trauma");
            DropTable("dbo.Modelo_Motivos");
            DropTable("dbo.Modelo_Examen");
            DropTable("dbo.Fechas");
            DropTable("dbo.Modelo_Datos");
            DropTable("dbo.RootObjects");
            DropTable("dbo.Form_Vaccinations");
            DropTable("dbo.Form_Vital_Signs");
            DropTable("dbo.Form_Blood_Pressure");
            DropTable("dbo.PatientModels");
        }
    }
}
