using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SoporteAurora.Models{

public class TicketRepuesto
{
    public int id_Ticket{get; set;}
    public int id_Repuesto {get; set;}
    public int Cantidad {get; set;}
    [ForeignKey("id_Ticket")]
    [JsonIgnore]
    public Ticket ticket {get; set;}
    [ForeignKey("id_Repuesto")]
    [JsonIgnore]
    public Repuesto repuesto {get;set;}
}
}