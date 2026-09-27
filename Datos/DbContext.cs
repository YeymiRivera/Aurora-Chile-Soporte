using Microsoft.EntityFrameworkCore;
using SoporteAurora.Models;
namespace SoporteAurora.Datos
{
    public class SoporteContext : DbContext
    {
        public SoporteContext(DbContextOptions<SoporteContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<ActivoTecnologico> ActivosTecnologicos { get; set; }
        public DbSet<Ticket_activo> Ticket_activos { get; set; }
        public DbSet<Tipo_activo> Tipos_activos{get;set;}
        public DbSet<Repuesto> Repuestos {get; set;}
        public DbSet<Mantenimiento> Mantenimientos {get;set;}
        public DbSet<Mantenimiento_Repuesto> Mantenimiento_repuestos {get; set;}
        public DbSet<TicketRepuesto> Ticket_repuestos {get;set;}
        public DbSet<Evidencia> Evidencias {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Mantenimiento_Repuesto>()
        .HasKey(ma=> new
        {
            ma.id_Mantenimiento,
            ma.id_Repuesto
        });
        modelBuilder.Entity<Ticket_activo>()
        .HasKey(ta => new
        {
            ta.id_Ticket,
            ta.id_activo
        });
        modelBuilder.Entity<TicketRepuesto>()
        .HasKey(tr=> new
        {
            tr.id_Ticket,
            tr.id_Repuesto
        });
}
        
    }
}