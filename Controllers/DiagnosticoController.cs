using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoporteAurora.Datos;
using SoporteAurora.Models;
using Microsoft.AspNetCore.Http;
[Route("api/[controller]")]
[ApiController]
public class DiagnosticoController : ControllerBase
{
    private readonly SoporteContext _context;

    public DiagnosticoController(SoporteContext context)
    {
        _context = context;
    }

    [HttpGet("ListarDiagnosticos")]
    public async Task<ActionResult> ListarDiagnosticos()
    {
        var diagnosticos=await _context.Diagnosticos.ToListAsync();
        return Ok(diagnosticos);
    }
    [HttpGet("BuscarDiagnostico/{codigo}")]
    public async Task<ActionResult> BuscarDiagnostico(string codigo)
    {
        var diagnostico = await (from d in _context.Diagnosticos
                      where d.id_Ticket == (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t.Id_Ticket).FirstOrDefault()
                      select d).FirstOrDefaultAsync();
        if (diagnostico == null)
        {
            return NotFound(new { message = "Diagnóstico no encontrado." });
        }
        return Ok(diagnostico);
    }

    [HttpPost("CrearDiagnostico")]
    public async Task<ActionResult> CrearDiagnostico(string codigo,  string descripcion, string observaciones, string codigo_encargado,string causa, string resultado )
    {
          var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var diagnostico = await (from d in _context.Diagnosticos
                      where d.id_Ticket == ticket.Id_Ticket
                      select d).FirstOrDefaultAsync();
        if (diagnostico != null)
        {
            return NotFound(new { message = "Diagnóstico ya existe." });
        }
      
        Diagnostico nuevoDiagnostico = new Diagnostico  
        {
            Id_Encargado = 0,
            Fecha = DateTime.UtcNow,
            Causa = causa,
            Resultado = resultado,
            Descripcion = descripcion,
            Observaciones = observaciones,
            id_Ticket = ticket.Id_Ticket
        };
        _context.Diagnosticos.Add(nuevoDiagnostico);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Diagnóstico creado exitosamente." });
    }
    
    [HttpPut("ActualizarDiagnostico/{codigo}")]
    public async Task<ActionResult> ActualizarDiagnostico(string codigo,  string descripcion, string observaciones, string codigo_encargado,string causa, string resultado)
    {
        var ticket = await (from t in _context.Tickets
                      where t.Codigo == codigo
                      select t).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket no encontrado." });
        }
        var diagnostico = await (from d in _context.Diagnosticos
                      where d.id_Ticket == ticket.Id_Ticket
                      select d).FirstOrDefaultAsync();
        if (diagnostico == null)
        {
            return NotFound(new { message = "Diagnóstico no encontrado." });
        }
        diagnostico.Descripcion = descripcion;
        diagnostico.Observaciones = observaciones;
        diagnostico.Causa = causa;
        diagnostico.Resultado = resultado;
        await _context.SaveChangesAsync();
        return Ok(new { message = "Diagnóstico actualizado exitosamente." });
    }
}

