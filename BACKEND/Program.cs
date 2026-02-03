using BACKEND.Data;
using BACKEND.Repositories;
using BACKEND.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Se Registra DbContext con EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Inyección de dependencias //
// Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PersonaRepository>();
builder.Services.AddScoped<RolRepository>();
builder.Services.AddScoped<RolOpcionesRepository>();
builder.Services.AddScoped<RolRolOpcionesRepository>();
builder.Services.AddScoped<RolUsuariosRepository>();
builder.Services.AddScoped<SessionRepository>();

// Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PersonaService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<RolOpcionesService>();
builder.Services.AddScoped<RolRolOpcionesService>();
builder.Services.AddScoped<RolUsuariosService>();
builder.Services.AddScoped<SessionService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de Autenticación JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agregar después UseAuthentication() para JWT
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.MapControllers();

app.Run();
