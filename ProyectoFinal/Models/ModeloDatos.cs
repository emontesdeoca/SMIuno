using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_Datos")]
    public class ModeloDatos
    {
        public int id { get; set; }
        public string Edad { get; set; }
        public virtual Fecha Fecha { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreResponsable { get; set; }
        public string NumeroContacto { get; set; }
        public string SeguroMedico { get; set; }
        public string Sexo { get; set; }
    }
}