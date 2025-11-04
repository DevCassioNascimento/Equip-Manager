using System;
using EquipManager.Domain.Enums;

namespace EquipManager.Domain.Entities
{
    // A classe Reservation representa a reserva de um equipamento
    // feita por um usuário em uma data específica.
    public class Reservation
    {
        // ----------------------------
        // 🆔 Identificador único da reserva
        // ----------------------------
        public int Id { get; set; }

        // ----------------------------
        // 🔗 Relacionamento com o equipamento reservado
        // (chave estrangeira)
        // ----------------------------
        public int EquipmentId { get; set; }

        // ----------------------------
        // Propriedade de navegação para o EF Core
        // Permite acessar o objeto Equipment completo
        // ----------------------------
        public Equipment Equipment { get; set; } = null!;

        // ----------------------------
        // 🔗 Relacionamento com o usuário que fez a reserva
        // (chave estrangeira)
        // ----------------------------
        public int UserId { get; set; }

        // ----------------------------
        // Propriedade de navegação para o EF Core
        // Permite acessar o objeto User completo
        // ----------------------------
        public User User { get; set; } = null!;

        // ----------------------------
        // 🗓️ Data e hora de início da reserva
        // ----------------------------
        public DateTime StartDate { get; set; }

        // ----------------------------
        // 🗓️ Data e hora de término da reserva
        // ----------------------------
        public DateTime EndDate { get; set; }

        // ----------------------------
        // ⚙️ Status da reserva
        // Usando o enum ReservationStatus (será criado)
        // ----------------------------
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        // ----------------------------
        // 📝 Observações opcionais
        // ----------------------------
        public string? Notes { get; set; }

        // ----------------------------
        // 🧾 Controle de auditoria
        // ----------------------------
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
