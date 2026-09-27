using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SoporteAurora.Models;
namespace SoporteAurora.Models{
public class Mantenimiento_Repuesto
{
    public int id_Repuesto{get;set;}
    public int id_Mantenimiento{get;set;}
    public int Cantidad {get;set;}
    [ForeignKey("id_Repuesto")]
    [JsonIgnore]
    public Repuesto repuesto{get; set;}
    [ForeignKey("id_Mantenimiento")]
    [JsonIgnore]
    public Mantenimiento mantenimiento{get; set;}
}
}