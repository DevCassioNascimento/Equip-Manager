using EquipManager.Application.Services;
using EquipManager.Domain.Interfaces;
using EquipManager.Infrastructure.Repositories;
using EquipManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EquipManager.API.Configurations
{
    // Classe estática para registrar dependências no container do ASP.NET
    public static class DependencyInjectionConfig
    {
        // Método de extensão chamado no Program.cs
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // ----------------------
            // 🐘 Configuração do Banco de Dados (PostgreSQL)
            // ----------------------

            // Lê as variáveis do arquivo .env
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

            // Monta a string de conexão dinâmica
            var connectionString =
                $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass}";

            // Registra o contexto do banco no container de serviços
            // Isso faz com que o AppDbContext esteja disponível para injeção em toda a aplicação
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            // ----------------------
            // 🔗 Injeção de dependências das camadas
            // ----------------------

            // Repositório e serviço de Equipment
            services.AddScoped<IEquipmentRepository, InMemoryEquipmentRepository>(); // depois trocaremos por o repositório real
            services.AddScoped<EquipmentService>();

            // Retorna o container de serviços configurado
            return services;
        }
    }
}
