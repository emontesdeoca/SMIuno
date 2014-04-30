using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Modelo_CoordenadasUno")]
    public class ModeloCoordenadasUno
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string latitudUno { get; set; }
        public string longitudUno { get; set; }
        public int HospId { get; set; }
    }
}