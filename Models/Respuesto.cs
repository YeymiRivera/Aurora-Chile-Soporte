using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SoporteAurora.Models
{
public class Repuesto
{
    [Key]
    public int Id_Repuesto {get;set;}
    public string Nombre {get; set;}
    public string Codigo {get; set;}
    public string Descripcion {get; set;}
    public int Stock {get; set;}
    public decimal Costo {get; set;}
    public string Estado {get;set;}
}
}