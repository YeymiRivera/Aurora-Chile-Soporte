using System.Net.Http.Json;
using SoporteAurora.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace SoporteAurora.Services
{
    public class UsuarioController: ControllerBase
    {
        private readonly HttpClient _httpClient;

        public UsuarioController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet("ObtenerUsuario/{codigo}")]
        public async Task<IActionResult> ObtenerUsuarioAsync(string codigo)
        {
            var usuario = await _httpClient.GetFromJsonAsync<UsuarioDTO>($"https://db4nx0n2-7080.brs.devtunnels.ms/scalar/v1#tag/empleado/GET/rrhh/empleados/{codigo}");
            if (usuario==null)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }
            return Ok(usuario);
        }
    }
}