using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacionBackend.Models
{
    public class Ciudad
    {
        public string Codigo { get; set; }

        [Column("CIUDAD")]
        public string NombreCiudad { get; set; }

        public string F3 { get; set; }
    }
}