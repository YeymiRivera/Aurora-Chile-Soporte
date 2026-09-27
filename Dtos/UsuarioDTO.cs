using Newtonsoft.Json;
namespace SoporteAurora.Dtos
{
public class UsuarioDTO
{
    [JsonProperty("nombre")]
    public string Nombre { get; set; }
    [JsonProperty("apellido")]
    public string Apellido { get; set; }
    [JsonProperty("correo")]
    public string Correo { get; set; }
    [JsonProperty("ci")]
    public string CI{ get; set; }


}}