using System.ComponentModel.DataAnnotations;

namespace SoporteAurora.Models
{
    public class Ticket
    {
        [Key]
        public int Id_Ticket { get; set; }
        public string Codigo { get; set; }
        public string CI_Usuario { get; set; }
        public string Tipo_Problema { get; set; }
        public string Prioridad { get; set; }
        public string Impacto { get; set; }
        public string Urgencia { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string CI_Encargado { get; set; }
        public DateTime Fecha { get; set; }
    }
}