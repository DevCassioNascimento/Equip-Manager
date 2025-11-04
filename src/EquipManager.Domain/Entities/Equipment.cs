using System;
using EquipManager.Domain.Enums;

namespace EquipManager.Domain.Entities
{
    // A classe Equipment representa um equipamento físico
    // que pode ser reservado ou utilizado em eventos.
    // Essa entidade será convertida em uma tabela pelo Entity Framework.
    public class Equipment
    {
        // ----------------------------
        // 🆔 Identificador único (Primary Key)
        // ----------------------------
        public int Id { get; set; }

        // ----------------------------
        // 📦 Nome do equipamento
        // Ex: "Caixa de Som JBL", "Projetor Epson"
        // ----------------------------
        public string Name { get; set; } = string.Empty;

        // ----------------------------
        // 🏷️ Categoria do equipamento
        // Ex: "Áudio", "Vídeo", "Iluminação", "Informática"
        // ----------------------------
        public string Category { get; set; } = string.Empty;

        // ----------------------------
        // 🧾 Número de patrimônio
        // Ex: "PAT-0001"
        // ----------------------------
        public string AssetNumber { get; set; } = string.Empty;

        // ----------------------------
        // 📍 Localização física
        // Ex: "Depósito Central", "Sala de Eventos"
        // ----------------------------
        public string Location { get; set; } = string.Empty;

        // ----------------------------
        // 📝 Descrição detalhada
        // ----------------------------
        public string? Description { get; set; }

        // ----------------------------
        // ⚙️ Status atual
        // Usando o enum EquipmentStatus (será criado na pasta Enums)
        // ----------------------------
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;

        // ----------------------------
        // 🗓️ Data de aquisição (opcional)
        // ----------------------------
        public DateTime? AcquisitionDate { get; set; }

        // ----------------------------
        // 🧾 Controle de auditoria
        // ----------------------------
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
