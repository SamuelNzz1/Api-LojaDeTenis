using ApiLoja.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona o contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

// Configura JSON para evitar ciclos infinitos
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Configura Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona um cache distribuído para suportar sessões
builder.Services.AddDistributedMemoryCache();

// Adiciona suporte para sessões
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Adiciona HttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configura o pipeline da aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession(); // ⚠️ Certifique-se de que está antes da autorização
app.UseAuthorization();
app.MapControllers();

app.Run();
