using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la conexión a la base de datos (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Agrega controladores para tu API

// Configuración de Swagger para documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en desarrollo
    app.UseSwaggerUI(); // Interfaz gráfica de Swagger
}

app.UseHttpsRedirection(); // Redirección HTTPS

app.UseAuthorization(); // Autorización (se puede extender si añades autenticación)

app.MapControllers(); // Mapea los controladores para los endpoints

app.Run(); // Ejecuta la aplicación
