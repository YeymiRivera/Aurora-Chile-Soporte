using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoporteAurora.Datos;
using SoporteAurora.Models;
using Microsoft.AspNetCore.Http;
[Route("api/[controller]")]
[ApiController]
public class RepuestoController : ControllerBase
{
    private readonly SoporteContext _context;

    public RepuestoController(SoporteContext context)
    {
        _context = context;
    }

    [HttpGet("ListarRepuestos")]
    public async Task<ActionResult> ListarRepuestos()
    {
        var repuestos=await _context.Repuestos.ToListAsync();
        return Ok(repuestos);
    }
    [HttpGet("BuscarRepuesto/{codigo}")]
    public async Task<ActionResult> BuscarRepuesto(string codigo)
    {
        var repuesto = await (from r in _context.Repuestos
                      where r.Codigo == codigo
                      select r).FirstOrDefaultAsync();
        if (repuesto == null)
        {
            return NotFound(new { message = "Repuesto no encontrado." });
        }
        return Ok(repuesto);
    }

    [HttpPost("CrearRepuesto")]
    public async Task<ActionResult> CrearRepuesto(string codigo, string nombre, string descripcion, decimal precio, int cantidad)
    {
        var repuestoExistente = await (from r in _context.Repuestos
                      where r.Codigo == codigo
                      select r).FirstOrDefaultAsync();
        if (repuestoExistente != null)
        {
            return NotFound(new { message = "Repuesto ya existe." });
        }
        Repuesto nuevoRepuesto = new Repuesto  
        {
            Codigo = codigo,
            Nombre = nombre,
            Descripcion = descripcion,
            Costo = precio,
            Stock = cantidad,
            Estado = "Disponible"
        };
        _context.Repuestos.Add(nuevoRepuesto);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Repuesto creado exitosamente." });
    }
    
    [HttpPut("ActualizarEstado/{codigo}")]
    public async Task<ActionResult> ActualizarMantenimientoEstado(string codigo, string nuevoEstado)
    {
        var repuesto = await (from r in _context.Repuestos
                      where r.Codigo == codigo
                      select r).FirstOrDefaultAsync();
        if (repuesto == null)
        {
            return NotFound(new { message = "Repuesto no encontrado." });
        }
        repuesto.Estado = nuevoEstado;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Estado del repuesto actualizado exitosamente." });
    }
    [HttpPut("ActualizarStock/{codigo}")]
    public async Task<ActionResult> ActualizarStock(string codigo, int cantidad)
    {
        var repuesto = await (from r in _context.Repuestos
                      where r.Codigo == codigo
                      select r).FirstOrDefaultAsync();
        if (repuesto == null)
        {
            return NotFound(new { message = "Repuesto no encontrado." });
        }
        repuesto.Stock = repuesto.Stock - cantidad;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Stock del repuesto actualizado exitosamente." });
    }
    [HttpDelete("EliminarRepuesto/{codigo}")]
    public async Task<ActionResult> EliminarRepuesto(string codigo)
    {
        var repuesto = await (from r in _context.Repuestos
                      where r.Codigo == codigo
                      select r).FirstOrDefaultAsync();
        if (repuesto == null)
        {
            return NotFound(new { message = "Repuesto no encontrado." });
        }
        
        if (repuesto.Estado == "Eliminado")
        {
            return BadRequest(new { message = "El repuesto ya ha sido eliminado." });
        }
       
       repuesto.Estado = "Eliminado";
        await _context.SaveChangesAsync();
        return Ok(new { message = "Repuesto eliminado exitosamente." });
    }
}

