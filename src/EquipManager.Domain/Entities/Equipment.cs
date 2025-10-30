
namespace EquipManager.Domain.Entities
{
    // A classe Equipment representa um equipamento físico
    // que pode ser reservado ou utilizado em eventos.
    public class Equipment
    {
        // Identificador único no sistema
        public int Id { get; set; }

        // Nome do equipamento (ex: “Caixa de Som JBL”, “Projetor Epson”)
        public string Name { get; set; } = string.Empty;

        // Descrição detalhada do equipamento
        public string? Description { get; set; }

        // Status atual (ex: Disponível, Reservado, Em manutenção)
        public string Status { get; set; } = "Disponível";

        // Data de aquisição (opcional, só como exemplo de campo adicional)
        public DateTime? AcquisitionDate { get; set; }
    }
}
