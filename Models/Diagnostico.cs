using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SoporteAurora.Models
{
    public class Diagnostico
    {
        [Key]
        public int Id_Diagnostico { get; set; }
        public int Id_Encargado { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Resultado { get; set; }
        public string Causa { get; set; }
        public string Observaciones { get; set; } 

        public int id_Ticket { get; set; }
        [ForeignKey("id_Ticket")]
        [JsonIgnore]
        public Ticket Ticket { get; set; }
    }
}