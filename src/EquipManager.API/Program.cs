// Importa o namespace onde está nossa configuração de dependência
using EquipManager.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

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
