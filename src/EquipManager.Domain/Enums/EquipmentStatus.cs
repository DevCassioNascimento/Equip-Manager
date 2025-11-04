namespace EquipManager.Domain.Enums
{
    // Enum que representa os possíveis estados de um equipamento.
    // Usado na entidade Equipment para indicar a situação atual do item.
    public enum EquipmentStatus
    {
        // 🟢 Equipamento livre e pronto para uso ou reserva
        Available = 1,

        // 🟡 Equipamento reservado para um evento futuro
        Reserved = 2,

        // 🔵 Equipamento em uso (retirado para um evento)
        InUse = 3,

        // 🔴 Equipamento em manutenção e indisponível para empréstimo
        Maintenance = 4
    }
}
