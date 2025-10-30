// Importa o namespace onde estão as entidades do domínio.
// O serviço precisará manipular objetos do tipo Equipment.
using EquipManager.Domain.Entities;

// Importa o namespace onde está a interface IEquipmentRepository.
// O serviço usa a interface para acessar os métodos de busca, cadastro e atualização de equipamentos,
// sem saber como eles são implementados (isso é responsabilidade da camada Infrastructure).
using EquipManager.Domain.Interfaces;

namespace EquipManager.Application.Services
{
    // A classe EquipmentService representa um serviço de aplicação.
    // Ela é responsável por coordenar as ações entre a API e o domínio.
    // Aqui ficam as regras de uso, como validações ou decisões de negócio.
    public class EquipmentService
    {
        // Campo privado para armazenar a dependência do repositório de equipamentos.
        // Ele será usado dentro dos métodos para acessar os dados.
        private readonly IEquipmentRepository _repository;

        // Construtor da classe.
        // O parâmetro 'repository' será injetado automaticamente pela API (via Dependency Injection).
        // Isso garante que o serviço pode usar qualquer implementação da interface IEquipmentRepository
        // (por exemplo, um repositório em memória, ou depois um repositório com banco de dados).
        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        // Método responsável por listar todos os equipamentos.
        // Chama o método GetAllAsync() do repositório e retorna a lista obtida.
        public async Task<IEnumerable<Equipment>> ListAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Método responsável por buscar um equipamento específico pelo ID.
        // Se o equipamento não for encontrado, retorna null.
        public async Task<Equipment?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Método responsável por adicionar um novo equipamento.
        // Aqui é possível colocar validações antes de salvar (ex: nome obrigatório, número de patrimônio único, etc).
        public async Task AddAsync(Equipment equipment)
        {
            // Exemplo simples de validação: verifica se o nome foi preenchido.
            if (string.IsNullOrWhiteSpace(equipment.Name))
                throw new ArgumentException("O nome do equipamento é obrigatório.");

            // Chama o repositório para adicionar o novo equipamento.
            await _repository.AddAsync(equipment);
        }

        // Método responsável por atualizar um equipamento existente.
        // Pode validar se o equipamento existe antes de tentar atualizar.
        public async Task UpdateAsync(Equipment equipment)
        {
            var existing = await _repository.GetByIdAsync(equipment.Id);

            if (existing == null)
                throw new InvalidOperationException("Equipamento não encontrado.");

            await _repository.UpdateAsync(equipment);
        }

        // Método responsável por deletar um equipamento.
        // Também faz uma verificação para garantir que o ID existe antes de excluir.
        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                throw new InvalidOperationException("Equipamento não encontrado para exclusão.");

            await _repository.DeleteAsync(id);
        }
    }
}
