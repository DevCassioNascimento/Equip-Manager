// Importa o namespace onde está nossa configuração de dependência
using EquipManager.API.Configurations;
using DotNetEnv;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);




// Teste para confirmar leitura do .env
DotNetEnv.Env.Load();

Console.WriteLine("===================================");
Console.WriteLine("🔍 Testando leitura do arquivo .env");
Console.WriteLine($"Host: {Environment.GetEnvironmentVariable("DB_HOST")}");
Console.WriteLine($"Banco: {Environment.GetEnvironmentVariable("DB_NAME")}");
Console.WriteLine($"Usuário: {Environment.GetEnvironmentVariable("DB_USER")}");
Console.WriteLine("===================================");








// ---------------------
// Configurações de serviços
// ---------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aqui entra a configuração personalizada para conectar as camadas:
// Faz o ASP.NET saber como criar EquipmentService e InMemoryEquipmentRepository
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

// ---------------------
// Pipeline de requisição HTTP
// ---------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "EquipManager API v1");
        options.RoutePrefix = string.Empty; // faz o Swagger abrir direto na raiz
    });
}

// app.UseHttpsRedirection(); // desativado por enquanto
app.UseAuthorization();

app.MapControllers();

app.Run();
