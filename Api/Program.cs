using Buscador.Business;
using Buscador.Data;
using Serilog;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Gemu.Business;


var builder = WebApplication.CreateBuilder(args);
// Configuración de autenticación con JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        // Obteniendo los valores de configuración
        var validIssuer = builder.Configuration["JWT:ValidIssuer"];
        var validAudience = builder.Configuration["JWT:ValidAudience"];
        var secret = builder.Configuration["JWT:SecretKey"];

        // Verifica si los valores son nulos o vacíos
        if (string.IsNullOrEmpty(validIssuer) || string.IsNullOrEmpty(validAudience) || string.IsNullOrEmpty(secret))
        {
            throw new InvalidOperationException("JWT configuration is missing or invalid.");
        }

        // Configuración de los parámetros de validación de tokens
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret))
        };
    });

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

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IPeticionRepository, PeticionRepository>();
builder.Services.AddScoped<IPeticionService, PeticionService>();

builder.Services.AddScoped<IAuthService, AuthService>();

// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Configuracion para poner tokens en el Swagger
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configurar middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
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
