using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SoporteAurora.Models
{
public class Tipo_activo
{
    [Key]
    public int Id_tipo{get;set;}
    public string Nombre {get; set;}
    public string Descripcion {get; set;}
}
}