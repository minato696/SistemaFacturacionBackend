namespace SistemaFacturacionBackend.Models
{
    public class Orden
    {
        public int Reg { get; set; }
        public DateTime Fecha { get; set; }
        public string OrdenCodigo { get; set; } // Cambié el nombre para evitar conflicto con el modelo
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
        public string AvisosBonif { get; set; }
        public string AvisosPagado { get; set; }
        public string Seg { get; set; }
        public string Comision5 { get; set; }
        public string Comision15 { get; set; }
        public string Canje { get; set; }
        public string Vendedor { get; set; }
        public string Tipo { get; set; }
        public string SeFactura { get; set; }
        public string RucCliente { get; set; }
        public string Categoria { get; set; }
    }
}
