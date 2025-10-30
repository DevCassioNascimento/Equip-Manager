// Importa o namespace onde está definida a entidade 'Equipment'.
// Isso permite que a interface abaixo use a classe Equipment diretamente sem precisar escrever o caminho completo.
using EquipManager.Domain.Entities;

// Define o namespace (ou “pacote”) em que esta interface está localizada.
// Mantém o código organizado por camadas e evita conflitos de nomes.
namespace EquipManager.Domain.Interfaces
{
    // Declaração da interface IEquipmentRepository.
    // Em C#, interfaces são como “contratos” — elas dizem o que uma classe deve fazer,
    // mas não dizem como isso deve ser feito.
    // Qualquer classe que implemente essa interface será obrigada a criar esses métodos.
    public interface IEquipmentRepository
    {
        // Método responsável por retornar todos os equipamentos.
        // O uso de 'Task<IEnumerable<Equipment>>' indica que é um método assíncrono (usa async/await)
        // e vai devolver uma lista (IEnumerable) de objetos do tipo Equipment.
        Task<IEnumerable<Equipment>> GetAllAsync();

        // Método que busca um equipamento específico pelo seu ID.
        // O retorno 'Task<Equipment?>' significa:
        // → É um método assíncrono.
        // → Retorna um único equipamento OU null (por isso o '?').
        Task<Equipment?> GetByIdAsync(int id);

        // Método para adicionar um novo equipamento ao sistema.
        // Recebe um objeto 'Equipment' e retorna uma Task (sem valor de retorno),
        // pois a operação pode envolver acesso a banco de dados (operação demorada).
        Task AddAsync(Equipment equipment);

        // Método para atualizar os dados de um equipamento existente.
        // Também é assíncrono e não retorna nada.
        Task UpdateAsync(Equipment equipment);

        // Método para excluir um equipamento com base em seu ID.
        // 'Task' indica que é uma operação assíncrona sem retorno (void assíncrono).
        Task DeleteAsync(int id);
    }
}
