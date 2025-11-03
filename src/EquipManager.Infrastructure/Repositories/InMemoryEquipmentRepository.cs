// Importa o namespace onde está a entidade 'Equipment'
using EquipManager.Domain.Entities;

// Importa a interface do domínio que este repositório vai implementar
using EquipManager.Domain.Interfaces;

namespace EquipManager.Infrastructure.Repositories
{
    // Esta classe implementa a interface IEquipmentRepository.
    // Como o nome indica, ela é uma versão "em memória" — ou seja,
    // os dados são guardados apenas enquanto o programa está rodando (não há banco de dados real aqui).
    public class InMemoryEquipmentRepository : IEquipmentRepository
    {
        // Lista privada que simula uma "tabela" de equipamentos em memória.
        private readonly List<Equipment> _equipments = new();

        // Construtor padrão — não precisamos inicializar nada aqui no momento.
        public InMemoryEquipmentRepository() { }

        // Método que retorna todos os equipamentos armazenados.
        // 'Task.FromResult' é usado para retornar um valor como se fosse assíncrono,
        // simulando o comportamento de uma consulta de banco de dados real.
        public Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return Task.FromResult(_equipments.AsEnumerable());
        }

        // Método que busca um equipamento pelo ID.
        // Usa LINQ (FirstOrDefault) para procurar o primeiro equipamento que tenha o ID solicitado.
        public Task<Equipment?> GetByIdAsync(int id)
        {
            var equipment = _equipments.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(equipment);
        }

        // Método que adiciona um novo equipamento à lista.
        // Simulamos o comportamento de um banco auto incrementando o ID.
        public Task AddAsync(Equipment equipment)
        {
            // Define um ID incremental (último + 1)
            equipment.Id = _equipments.Count + 1;

            // Adiciona o equipamento à lista em memória
            _equipments.Add(equipment);

            // Retorna uma Task concluída (padrão em métodos assíncronos sem retorno)
            return Task.CompletedTask;
        }

        // Método que atualiza os dados de um equipamento existente.
        public Task UpdateAsync(Equipment equipment)
        {
            // Busca o equipamento pelo ID
            var existing = _equipments.FirstOrDefault(e => e.Id == equipment.Id);

            // Se existir, atualiza os campos
            if (existing != null)
            {
                existing.Name = equipment.Name;
                existing.Description = equipment.Description;
                existing.Status = equipment.Status;
            }

            return Task.CompletedTask;
        }

        // Método que exclui um equipamento da lista.
        public Task DeleteAsync(int id)
        {
            // Busca o equipamento pelo ID
            var equipment = _equipments.FirstOrDefault(e => e.Id == id);

            // Se encontrado, remove da lista
            if (equipment != null)
                _equipments.Remove(equipment);

            return Task.CompletedTask;
        }
    }
}

