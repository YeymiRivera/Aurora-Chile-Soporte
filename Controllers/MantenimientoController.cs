using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoporteAurora.Datos;
using SoporteAurora.Models;
using Microsoft.AspNetCore.Http;
using SoporteAurora.Services;
[Route("api/[controller]")]
[ApiController]
public class MantenimientoController : ControllerBase
{
    private readonly SoporteContext _context;
    private UsuarioController _usuarioController;

    public MantenimientoController(SoporteContext context)
    {
        _context = context;
    }

    [HttpGet("ListarMantenimientos")]
    public async Task<ActionResult> ListarMantenimientos()
    {
        var mantenimientos=await _context.Mantenimientos.ToListAsync();
        return Ok(mantenimientos);
    }
    [HttpGet("BuscarMantenimiento/{codigo}")]
    public async Task<ActionResult> BuscarMantenimiento(string codigo)
    {
        var mantenimiento = await (from m in _context.Mantenimientos
                      where m.id_Ticket == (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t.Id_Ticket).FirstOrDefault()
                      select m).FirstOrDefaultAsync();
        if (mantenimiento == null)
        {
            return NotFound(new { message = "Mantenimiento no encontrado." });
        }
        return Ok(mantenimiento);
    }

    [HttpPost("CrearMantenimiento")]
    public async Task<ActionResult> CrearMantenimiento(string codigo_activo,string codigo, string tipo, string descripcion,  string observaciones, string codigoResponsable)
    {
        var responsable= await _usuarioController.ObtenerUsuarioAsync(codigoResponsable);
        if (responsable == null)
        {
            return NotFound(new { message = "Responsable no encontrado." });
        }
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var mantenimiento = await (from m in _context.Mantenimientos
                      where m.id_Ticket == ticket.Id_Ticket
                      select m).FirstOrDefaultAsync();
        if (mantenimiento != null)
        {
            return NotFound(new { message = "Mantenimiento ya existe." });
        }
        var activo = await (from a in _context.ActivosTecnologicos
                      where a.Codigo_Inventario == codigo_activo
                      select a).FirstOrDefaultAsync();
        if (activo == null)
        {
            return NotFound(new { message = "Activo tecnológico no encontrado." });
        }
        Mantenimiento nuevoMantenimiento = new Mantenimiento
        {
           
            Fecha = DateTime.Now,
            Tipo = tipo,
            Descripcion = descripcion,
            Observaciones = observaciones,
            Costo = 0, 
            Estado = "En proceso",
            id_Activo = activo.Id_Activo,
            id_Ticket = ticket.Id_Ticket
        };
        _context.Mantenimientos.Add(nuevoMantenimiento);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Mantenimiento creado exitosamente." });
    }
    
    [HttpPost("AgregarRepuestoAMantenimiento/{codigo}")]
    public async Task<ActionResult> AgregarRepuestoAMantenimiento(string codigo, string codigoRepuesto, int cantidad)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var mantenimiento = await (from m in _context.Mantenimientos
                      where m.id_Ticket == ticket.Id_Ticket
                      select m).FirstOrDefaultAsync();
        if (mantenimiento == null)
        {
            return NotFound(new { message = "Mantenimiento no encontrado." });
        }
        var repuesto = await (from r in _context.Repuestos
                      where r.Codigo == codigoRepuesto
                      select r).FirstOrDefaultAsync();
        if (repuesto == null)
        {
            return NotFound(new { message = "Repuesto no encontrado." });
        }
        var ticketRepuestoExistente = await (from tr in _context.Ticket_repuestos
                      where tr.id_Ticket == ticket.Id_Ticket && tr.id_Repuesto == repuesto.Id_Repuesto
                      select tr).FirstOrDefaultAsync();
        if (ticketRepuestoExistente != null)
        {
            return BadRequest(new { message = "El repuesto ya ha sido agregado al mantenimiento." });
        }
        if (repuesto.Stock <= 0&& repuesto.Stock < cantidad)
        {
            return BadRequest(new { message = "No hay stock disponible para el repuesto." });
        }
        mantenimiento.Costo += repuesto.Costo * cantidad;
        repuesto.Stock -= cantidad;
        TicketRepuesto ticketRepuesto = new TicketRepuesto
        {
            id_Ticket = ticket.Id_Ticket,
            id_Repuesto = repuesto.Id_Repuesto,
            Cantidad = cantidad
        };
        _context.Ticket_repuestos.Add(ticketRepuesto);
        await _context.SaveChangesAsync();
        Mantenimiento_Repuesto mantenimientoRepuesto = new Mantenimiento_Repuesto
        {
            id_Mantenimiento = mantenimiento.Id_Mantenimiento,
            id_Repuesto = repuesto.Id_Repuesto,
            Cantidad = cantidad
        };
        _context.Mantenimiento_repuestos.Add(mantenimientoRepuesto);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Repuesto agregado al mantenimiento exitosamente." });
    }
    [HttpPut("ActualizarMantenimientoEstado/{codigo}")]
    public async Task<ActionResult> ActualizarMantenimientoEstado(string codigo, string nuevoEstado)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var mantenimiento = await (from m in _context.Mantenimientos
                      where m.id_Ticket == ticket.Id_Ticket
                      select m).FirstOrDefaultAsync();
        if (mantenimiento == null)
        {
            return NotFound(new { message = "Mantenimiento no encontrado." });
        }
        mantenimiento.Estado = nuevoEstado;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Estado del mantenimiento actualizado exitosamente." });
    }
    [HttpPut("ActualizarMantenimiento/{codigo}")]
    public async Task<ActionResult> ActualizarMantenimiento(decimal costo, string codigo, string descripcion, string observaciones)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var mantenimiento = await (from m in _context.Mantenimientos
                      where m.id_Ticket == ticket.Id_Ticket
                      select m).FirstOrDefaultAsync();
        if (mantenimiento == null)
        {
            return NotFound(new { message = "Mantenimiento no encontrado." });
        }
       
        mantenimiento.Descripcion = descripcion;
        mantenimiento.Costo = costo;
        mantenimiento.Observaciones = observaciones;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Mantenimiento actualizado exitosamente." });
    }
    [HttpDelete("EliminarMantenimiento/{codigo}")]
    public async Task<ActionResult> EliminarMantenimiento(string codigo)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Mantenimiento no encontrado." });
        }
        var mantenimiento = await (from m in _context.Mantenimientos
                      where m.id_Ticket == ticket.Id_Ticket
                      select m).FirstOrDefaultAsync();
        if (mantenimiento == null)
        {
            return NotFound(new { message = "Mantenimiento no encontrado." });
        }
        if (mantenimiento.Estado == "Eliminado")
        {
            return BadRequest(new { message = "El mantenimiento ya ha sido eliminado." });
        }
        if (mantenimiento.Estado != "Pendiente" )
        {
            return BadRequest(new { message = "El mantenimiento no se puede eliminar." });
        }
       ticket.Estado = "Eliminado";
        await _context.SaveChangesAsync();
        return Ok(new { message = "Mantenimiento eliminado exitosamente." });
    }
}

