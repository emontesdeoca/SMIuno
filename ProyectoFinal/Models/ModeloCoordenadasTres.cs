using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_CoordenadasTres")]
    public class ModeloCoordenadasTres
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string latitudTres { get; set; }
        public string longitudTres { get; set; }
        public int HospId { get; set; }
    }
}