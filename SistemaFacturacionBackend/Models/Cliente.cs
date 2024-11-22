namespace SistemaFacturacionBackend.Models
{
    public class Cliente
    {
        public string Ruc { get; set; }
        public string NombreCliente { get; set; } // Asegúrate de que este sea el nombre correcto
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Vendedor { get; set; }
        public string Pago { get; set; }
        public string Dias { get; set; }
    }
}
