namespace EquipManager.Domain.Enums
{
    // Enum que representa os diferentes estados possíveis de uma reserva.
    // É usado para acompanhar o progresso do pedido de reserva.
    public enum ReservationStatus
    {
        // 🕓 Aguardando aprovação do administrador ou técnico
        Pending = 1,

        // ✅ Reserva aprovada e confirmada
        Approved = 2,

        // ❌ Reserva rejeitada ou cancelada
        Rejected = 3,

        // 🔚 Reserva concluída (equipamento devolvido)
        Completed = 4
    }
}
