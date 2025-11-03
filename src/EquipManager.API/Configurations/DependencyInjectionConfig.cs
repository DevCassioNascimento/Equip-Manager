// Importa as camadas Application e Infrastructure
using EquipManager.Application.Services;
using EquipManager.Domain.Interfaces;
using EquipManager.Infrastructure.Repositories;

namespace EquipManager.API.Configurations
{
    // Classe estática para registrar dependências no container do ASP.NET
    public static class DependencyInjectionConfig
    {
        // Método de extensão que adiciona os serviços à injeção de dependência
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Aqui “ensinamos” o ASP.NET a criar instâncias quando precisar:

            // Sempre que alguém pedir um IEquipmentRepository,
            // o sistema entrega um InMemoryEquipmentRepository.
            services.AddSingleton<IEquipmentRepository, InMemoryEquipmentRepository>();

            // Sempre que alguém pedir um EquipmentService,
            // o sistema cria um novo com base no construtor.
            services.AddScoped<EquipmentService>();

            // Retorna o container para continuar encadeando configurações
            return services;
        }
    }
}

