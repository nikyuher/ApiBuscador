using Buscador.Business;
using Buscador.Data;
using Serilog;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión

// Configuración del entorno y la cadena de conexión
var configuration = builder.Configuration;
var environment = configuration["Environment"];

var connectionString = environment == "Docker" ?
    configuration.GetConnectionString("BuscadorDB") :
    configuration.GetConnectionString("BuscadorDBlocal");

// Registrar DbContext con la cadena de conexión
builder.Services.AddDbContext<BuscadorContext>(options =>
    options.UseSqlServer(connectionString));

// Registro de servicios de la aplicación
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<ICiudadService, CiudadService>();

// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BuscadorContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Error durante la migración de la base de datos.");
    }
}

app.Run();
