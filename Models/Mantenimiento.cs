using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SoporteAurora;
namespace SoporteAurora.Models
{
public class Mantenimiento
{
    [Key]
    public int Id_Mantenimiento {get; set;}
    public string Codigo_Responsable {get; set;}
    public DateTime Fecha {get; set;}
    public string Tipo {get; set;}
    public string Descripcion {get; set;}
    public decimal Costo {get; set;}
    public string Observaciones {get; set;}
    public string Estado {get; set;}
    public int id_Activo {get; set;}
    public int id_Ticket {get; set;}
    [ForeignKey("id_Activo")]
    [JsonIgnore]
    public ActivoTecnologico activo {get; set;}
    [ForeignKey("id_Ticket")]
    [JsonIgnore]
    public Ticket ticket {get; set;}
}
}