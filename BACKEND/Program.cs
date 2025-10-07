using BACKEND.Data;
using BACKEND.Repositories;
using BACKEND.Services;
using Microsoft.EntityFrameworkCore;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Agregar después UseAuthentication() para JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
