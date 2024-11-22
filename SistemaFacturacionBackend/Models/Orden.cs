
namespace SistemaFacturacionBackend.Data.Models
{
    public class Orden
    {
        public int Reg { get; set; }
        public DateTime Fecha { get; set; }
        public string OrdenNumero { get; set; }
        public string Rv { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public string Motivo { get; set; }
        public double NetoS { get; set; }
        public double NetoUs { get; set; }
        public string Agencia { get; set; }
        public string Emisora { get; set; }
        public string Ciudad { get; set; }
        public string NFactura { get; set; }
        public string Periodo { get; set; }
        public string OrdenCompra { get; set; }
        public string FtAgencia { get; set; }
        public string NetoAgencia { get; set; }
        public string Observaciones { get; set; }
        public string Codigo { get; set; }
        public string Facturado { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
