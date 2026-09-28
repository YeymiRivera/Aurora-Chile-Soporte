using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SoporteAurora.Models
{
    public class ActivoTecnologico
    {
        [Key]
        public int Id_Activo { get; set; }
        public string Codigo_Inventario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Numero_Serie { get; set; }
        public DateOnly Fecha_Compra { get; set; }
        public DateOnly Fecha_Vencimiento_Garantia { get; set; }
        public string Estado { get; set; }
        public int id_tipo_activo {get; set;}
        [ForeignKey("id_tipo_activo")]
        [JsonIgnore]
        public Tipo_activo tipo_Activo{get; set;}
    }
}