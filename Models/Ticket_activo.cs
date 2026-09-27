using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SoporteAurora.Models
{
    public class Ticket_activo
    {
        public int id_Ticket { get; set; }
        public int id_activo { get; set; }
        [ForeignKey("id_Ticket")]
        [JsonIgnore]
        public Ticket Ticket { get; set; }
        [ForeignKey("id_activo")]
        [JsonIgnore]
        public ActivoTecnologico Activo { get; set; }
    }
}