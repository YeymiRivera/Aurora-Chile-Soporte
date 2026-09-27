using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoporteAurora.Datos;
using SoporteAurora.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using SoporteAurora.Services;
[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly SoporteContext _context;
    private UsuarioController _userService;

    public TicketController(SoporteContext context)
    {
        _context = context;
    }

    [HttpGet("ListarTickets/Pendientes")]
    public async Task<ActionResult> ListarTickets()
    {
        var tickets=await _context.Tickets.ToListAsync();
        return Ok(tickets);
    }
    [HttpGet("BuscarTicket/{codigo}")]
    public async Task<ActionResult> BuscarTicket(string codigo)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        return Ok(ticket);
    }

    [HttpPost("CrearTicket")]
    public async Task<ActionResult> CrearTicket(string CI_Usuario, string Tipo_Problema, string Prioridad, 
    string Impacto, string Urgencia, string Descripcion,string Codigo_Inventario)
    {
        var usuario = await _userService.ObtenerUsuarioAsync(CI_Usuario);
        if (usuario == null)
        {
            return NotFound(new { message = "Usuario no encontrado." });
        }
        var activo = await (
            from a in _context.ActivosTecnologicos
            where a.Codigo_Inventario == Codigo_Inventario
            select a
        ).FirstOrDefaultAsync();
        if (activo == null)
        {
            return NotFound(new { message = "No se encontró un activo con el código de inventario proporcionado." });
        }
        var ticket_activo=await(
            from ta in _context.Ticket_activos
            where ta.Activo.Codigo_Inventario == Codigo_Inventario && (
            from t in _context.Tickets 
            where t.Id_Ticket==ta.id_Ticket  && t.Estado=="Pendiente" 
            select t).Any()
            select ta
        ).FirstOrDefaultAsync();
        if(ticket_activo!=null)
        {
            return NotFound(new { message = "Ya existe un ticket pendiente para este activo." });
        }
       
        Ticket ticket = new Ticket
        {
            CI_Usuario = CI_Usuario,
            Tipo_Problema = Tipo_Problema,
            Prioridad = Prioridad,
            Impacto = Impacto,
            Codigo=Codigo_Inventario+"_"+CI_Usuario,
            Urgencia = Urgencia,
            Descripcion = Descripcion,
            Estado = "Pendiente",
            Fecha = DateTime.UtcNow,
        };
      
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
         
         Ticket_activo ticket_acti= new Ticket_activo
    {
        id_Ticket = ticket.Id_Ticket,
        id_activo = activo.Id_Activo
    };
    _context.Ticket_activos.Add(ticket_acti);
    await _context.SaveChangesAsync();
        return Ok(new { message = "Ticket creado exitosamente", Codigo = ticket.Codigo }); 
      
    }
    
    [HttpPut("ActualizarEstadoTicket/{codigo}")]
    public async Task<ActionResult> ActualizarEstadoTicket(string codigo, string nuevoEstado)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        ticket.Estado = nuevoEstado;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Estado del ticket actualizado exitosamente." });
    }
[HttpPut("AsignarEncargadoTicket/{codigo}")]
    public async Task<ActionResult> AsignarEncargadoTicket(string codigo, string CIencargado)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var usuario = await _userService.ObtenerUsuarioAsync(CIencargado);
        if (usuario == null)
        {
            return NotFound(new { message = "Usuario encargado no encontrado." });
        }
        ticket.CI_Encargado = CIencargado;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Encargado asignado al ticket exitosamente." });
    }
    [HttpDelete("EliminarTicket/{codigo}")]
    public async Task<ActionResult> EliminarTicket(string codigo)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        if (ticket.Estado == "Eliminado")
        {
            return BadRequest(new { message = "El ticket ya ha sido eliminado." });
        }
        if (ticket.Estado != "Pendiente" )
        {
            return BadRequest(new { message = "El ticket no se puede eliminar." });
        }
       ticket.Estado = "Eliminado";
        await _context.SaveChangesAsync();
        return Ok(new { message = "Ticket eliminado exitosamente." });
    }
}