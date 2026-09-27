using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SoporteAurora.Models{

    public class Evidencia
    {
        [Key]
        public int Id_Evidencia {get; set;}
        public int id_Ticket {get; set;}
        public int Id_Responsable {get; set;}
        public DateTime Fecha {get; set;}
        public string Tipo {get;set;}
        public string Descripcion { get; set;}
        public string Archivo { get; set;}
        [ForeignKey("id_Ticket")]
        [JsonIgnore]
        public Ticket ticket {get; set;}

    }
}