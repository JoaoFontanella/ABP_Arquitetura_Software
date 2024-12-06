using Microsoft.EntityFrameworkCore;
using CursoOnlineAPI;
using CursoOnlineAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os de controlador, Swagger e DbContext
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do DbContext com SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura��o do middleware
app.UseSwagger();
app.UseSwaggerUI(); // Habilita o Swagger UI para testar as APIs facilmente

app.UseHttpsRedirection();

app.MapControllers(); // Mapeia as rotas dos controladores

app.Run();
