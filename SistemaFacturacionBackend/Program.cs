using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la conexi�n a la base de datos (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Agrega controladores para tu API

// Configuraci�n de Swagger para documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en desarrollo
    app.UseSwaggerUI(); // Interfaz gr�fica de Swagger
}

app.UseHttpsRedirection(); // Redirecci�n HTTPS

app.UseAuthorization(); // Autorizaci�n (se puede extender si a�ades autenticaci�n)

app.MapControllers(); // Mapea los controladores para los endpoints

app.Run(); // Ejecuta la aplicaci�n
