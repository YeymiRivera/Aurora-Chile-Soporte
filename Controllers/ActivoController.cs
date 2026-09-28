using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoporteAurora.Datos;
using SoporteAurora.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using SoporteAurora.Services;
[Route("api/[controller]")]
[ApiController]
public class ActivoController : ControllerBase
{
    private readonly SoporteContext _context;
    private UsuarioController _userService;

    public ActivoController(SoporteContext context)
    {
        _context = context;
    }

    [HttpGet("ListarActivos")]
    public async Task<ActionResult> ListarActivos()
    {
        var activos=await _context.ActivosTecnologicos.ToListAsync();
        return Ok(activos);
    }
    [HttpGet("BuscarActivo/{codigo}")]
    public async Task<ActionResult> BuscarActivo(string codigo)
    {
        var activo = await (from a in _context.ActivosTecnologicos
                      where a.Codigo_Inventario == codigo
                      select a).FirstOrDefaultAsync();
        if (activo == null)
        {
            return NotFound(new { message = "Activo no encontrado." });
        }
        return Ok(activo);
    }
    [HttpPost("CrearActivo")]
    public async Task<ActionResult> CrearActivo(string Codigo_Inventario, string Nombre, string Descripcion,string Marca, string Modelo, string Numero_Serie, DateOnly Fecha_Compra, DateOnly Fecha_Vencimiento_Garantia, string Estado, int id_tipo_activo)
    {
        var activoExistente = await (from a in _context.ActivosTecnologicos
                      where a.Codigo_Inventario == Codigo_Inventario
                      select a).FirstOrDefaultAsync();
        if (activoExistente != null)
        {
            return NotFound(new { message = "Activo ya existe." });
        }
    {
        ActivoTecnologico activo = new ActivoTecnologico
        {
            Codigo_Inventario = Codigo_Inventario,
            Marca = Marca,
            Modelo = Modelo,
            Numero_Serie = Numero_Serie,
            Fecha_Compra = Fecha_Compra,
            Fecha_Vencimiento_Garantia = Fecha_Vencimiento_Garantia,
            Estado = Estado,
            id_tipo_activo = id_tipo_activo
        };
        _context.ActivosTecnologicos.Add(activo);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Activo creado exitosamente", Codigo_Inventario = activo.Codigo_Inventario });
    }}
}