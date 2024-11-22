using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacionBackend.Models
{
    [Table("CLIENTES")] // Mapeo a la tabla "CLIENTES" de PostgreSQL
    public class Cliente
    {
        [Key] // Llave primaria
        [Column("RUC")]
        public string Ruc { get; set; }

        [Column("CLIENTE")]
        [Required]
        [StringLength(150)]
        public string ClienteNombre { get; set; }

        [Column("DIRECCION")]
        [StringLength(150)]
        public string Direccion { get; set; }

        [Column("TELEFONO")]
        [StringLength(11)]
        public string Telefono { get; set; }

        [Column("EMAIL")]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Column("VENDEDOR")]
        [StringLength(50)]
        public string Vendedor { get; set; }

        [Column("PAGO")]
        [StringLength(10)]
        public string Pago { get; set; }

        [Column("DIAS")]
        [StringLength(50)]
        public string Dias { get; set; }
    }
}
