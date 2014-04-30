using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_Trauma")]
    public class ModeloTrauma
    {
        public int id { get; set; }
        public string Nivel { get; set; }
        public string Posicion { get; set; }
    }
}