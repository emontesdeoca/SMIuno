using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_Examen")]
    public class ModeloExamen
    {
        public int id { get; set; }
        public string Abdomen { get; set; }
        public string ApCardio { get; set; }
        public string ApRespiratorio { get; set; }
        public string Fc { get; set; }
        public string Fr { get; set; }
        public string Gasgow { get; set; }
        public string Genitourinatorio { get; set; }
        public string SistemaNervioso { get; set; }
        public string Ta { get; set; }
        public string Taxilar { get; set; }
        public string Trectal { get; set; }
    }
}