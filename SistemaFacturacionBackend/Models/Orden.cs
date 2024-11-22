using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacionBackend.Models
{
    [Table("ORDENES")] // Mapeo a la tabla "ORDENES" de PostgreSQL
    public class Orden
    {
        [Key] // Llave primaria
        [Column("REG")]
        public int Reg { get; set; }

        [Column("FECHA")]
        [Required]
        public DateTime Fecha { get; set; }

        [Column("ORDEN")]
        [StringLength(50)]
        public string OrdenCodigo { get; set; }

        [Column("RV")]
        [StringLength(2)]
        public string Rv { get; set; }

        [Column("CLIENTE")]
        [StringLength(150)]
        public string Cliente { get; set; }

        [Column("PRODUCTO")]
        [StringLength(150)]
        public string Producto { get; set; }

        [Column("MOTIVO")]
        [StringLength(150)]
        public string Motivo { get; set; }

        [Column("NETO_S")]
        public double Neto_S { get; set; }

        [Column("NETO_US")]
        public double Neto_Us { get; set; }

        [Column("AGENCIA")]
        [StringLength(50)]
        public string Agencia { get; set; }

        [Column("EMISORA")]
        [StringLength(50)]
        public string Emisora { get; set; }

        [Column("CIUDAD")]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [Column("N_FACTURA")]
        [StringLength(50)]
        public string NFactura { get; set; }

        [Column("PERIODO")]
        [StringLength(50)]
        public string Periodo { get; set; }

        [Column("ORDEN_COMPRA")]
        [StringLength(50)]
        public string OrdenCompra { get; set; }

        [Column("FT_AGENCIA")]
        [StringLength(50)]
        public string FtAgencia { get; set; }

        [Column("NETO_AGENCIA")]
        [StringLength(50)]
        public string NetoAgencia { get; set; }

        [Column("OBSERVACIONES")]
        [StringLength(200)]
        public string Observaciones { get; set; }

        [Column("CODIGO")]
        [StringLength(100)]
        public string Codigo { get; set; }

        [Column("FACTURADO")]
        [StringLength(2)]
        public string Facturado { get; set; }

        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }

        [Column("AVISOS_BONIF")]
        [StringLength(10)]
        public string AvisosBonif { get; set; }

        [Column("AVISOS_PAGADO")]
        [StringLength(100)]
        public string AvisosPagado { get; set; }

        [Column("SEG")]
        [StringLength(100)]
        public string Seg { get; set; }

        [Column("COMISION_5")]
        [StringLength(50)]
        public string Comision5 { get; set; }

        [Column("COMISION_15")]
        [StringLength(50)]
        public string Comision15 { get; set; }

        [Column("CANJE")]
        [StringLength(50)]
        public string Canje { get; set; }

        [Column("VENDEDOR")]
        [StringLength(100)]
        public string Vendedor { get; set; }

        [Column("TIPO")]
        [StringLength(100)]
        public string Tipo { get; set; }

        [Column("SE_FACTURA")]
        [StringLength(200)]
        public string SeFactura { get; set; }

        [Column("RUC_CLIENTE")]
        [StringLength(20)]
        public string RucCliente { get; set; }

        [Column("CATEGORIA")]
        [StringLength(200)]
        public string Categoria { get; set; }
    }
}
