namespace EquipManager.Domain.Enums
{
    // Enum que representa os diferentes papéis (perfis)
    // de usuário dentro do sistema EquipManager.
    public enum UserRole
    {
        // 👑 Administrador do sistema — possui acesso total
        Admin = 1,

        // 🧰 Técnico de TI — responsável pela manutenção e controle dos equipamentos
        Technician = 2,

        // 👤 Usuário comum — pode reservar e devolver equipamentos
        User = 3
    }
}
