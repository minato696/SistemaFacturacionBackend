using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteMotivo> ClienteMotivos { get; set; }
        public DbSet<Descripcion> Descripciones { get; set; }
        public DbSet<DetVenta> DetVentas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<VendedorAnt> VendedoresAnt { get; set; }
        public DbSet<Venta> Ventas { get; set; }


    }

}