using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_Motivos")]
    public class ModeloMotivos
    {
        public int id { get; set; }
        public string Alergias { get; set; }
        public string EnfermedadesPrevias { get; set; }
        public string InicioSintomas { get; set; }
        public string Medicacion { get; set; }
        public string MotivoConsulta { get; set; }
    }
}