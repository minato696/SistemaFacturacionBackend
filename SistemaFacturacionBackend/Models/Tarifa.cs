
namespace SistemaFacturacionBackend.Data.Models
{
    public class Tarifa
    {
        public string Codigo { get; set; }
        public string Radio { get; set; }
        public string Ciudad { get; set; }
        public double TarifaValor { get; set; }
        public string Periodo { get; set; }
        public string Moneda { get; set; }
    }

}
