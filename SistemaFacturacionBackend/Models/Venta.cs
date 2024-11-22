
namespace SistemaFacturacionBackend.Data.Models
{
    public class Venta
    {
        public string Cod_Vta { get; set; }
        public string Ruc { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double BrutoMN { get; set; }
        public double BaseMN { get; set; }
        public double IgvMN { get; set; }
        public double TotalMN { get; set; }
        public double BrutoME { get; set; }
        public double BaseME { get; set; }
        public double IgvME { get; set; }
        public double TotalME { get; set; }
        public string Dscto { get; set; }
        public string Orden { get; set; }
        public string Orden_Compra { get; set; }
        public string N_Certificacion { get; set; }
        public string Agencia { get; set; }
        public string Moneda { get; set; }
        public string Serie { get; set; }
        public string CondPago { get; set; }
    }

}
