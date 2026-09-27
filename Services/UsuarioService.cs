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
            var usuario = await _httpClient.GetFromJsonAsync<UsuarioDTO>($"https://localhost:44391/api/Usuario/BuscarUsuario/{codigo}");
            if (usuario==null)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }
            return Ok(usuario);
        }
    }
}