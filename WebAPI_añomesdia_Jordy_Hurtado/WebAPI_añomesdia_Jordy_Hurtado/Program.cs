
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI_añomesdia_Jordy_Hurtado.Data;
using WebAPI_añomesdia_Jordy_Hurtado.Models;
using WebAPI_añomesdia_Jordy_Hurtado.Service;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Base de datos
builder.Services.AddDbContext<DbConexion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<CursoService>();

builder.Services.AddScoped<IPasswordHasher<User>,
    PasswordHasher<User>>();


builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();