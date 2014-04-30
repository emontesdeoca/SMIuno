using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_CoordenadasDos")]
    public class ModeloCoordenadasDos
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string latitudDos { get; set; }
        public string longitudDos { get; set; }
    }
}