namespace SistemaFacturacionBackend.Data.Models
{
    public class Orden
    {
        public int Reg { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroOrden { get; set; } // Cambiado de "Orden"
        public string Rv { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public string Motivo { get; set; }
        public double Neto_S { get; set; }
        public double Neto_Us { get; set; }
        public string Agencia { get; set; }
        public string Emisora { get; set; }
        public string Ciudad { get; set; }
        public string N_Factura { get; set; }
        public string Periodo { get; set; }
        public string Orden_Compra { get; set; }
        public string Ft_Agencia { get; set; }
        public string Neto_Agencia { get; set; }
        public string Observaciones { get; set; }
        public string Codigo { get; set; }
        public string Facturado { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Avisos_Bonif { get; set; }
        public string Avisos_Pagado { get; set; }
        public string Seg { get; set; }
        public string Comision_5 { get; set; }
        public string Comision_15 { get; set; }
        public string Canje { get; set; }
        public string Vendedor { get; set; }
        public string Tipo { get; set; }
        public string Se_Factura { get; set; }
        public string Ruc_Cliente { get; set; }
        public string Categoria { get; set; }
    }
}
