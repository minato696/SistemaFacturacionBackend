
namespace SistemaFacturacionBackend.Data.Models
{
    public class Venta
    {
        public string CodVta { get; set; }
        public string Ruc { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double BrutoMn { get; set; }
        public double BaseMn { get; set; }
        public double IgvMn { get; set; }
        public double TotalMN { get; set; }
        public double BrutoMe { get; set; }
        public double BaseMe { get; set; }
        public double IgvMe { get; set; }
        public double TotalMe { get; set; }
        public string Dscto { get; set; }
        public string Orden { get; set; }
        public string OrdenCompra { get; set; }
        public string NCertificacion { get; set; }
        public string Agencia { get; set; }
        public string Moneda { get; set; }
        public string Serie { get; set; }
        public string CondPago { get; set; }
    }
}
