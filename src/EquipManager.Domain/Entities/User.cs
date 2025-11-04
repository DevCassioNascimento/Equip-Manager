using System;
using EquipManager.Domain.Enums;

namespace EquipManager.Domain.Entities
{
    // A classe User representa uma pessoa que utiliza o sistema,
    // podendo ser administrador, técnico ou usuário comum.
    public class User
    {
        // ----------------------------
        // 🆔 Identificador único do usuário
        // ----------------------------
        public int Id { get; set; }

        // ----------------------------
        // 👤 Nome completo do usuário
        // ----------------------------
        public string FullName { get; set; } = string.Empty;

        // ----------------------------
        // 📧 E-mail institucional ou pessoal
        // ----------------------------
        public string Email { get; set; } = string.Empty;

        // ----------------------------
        // 🔒 Senha (criptografada no futuro, com BCrypt)
        // ----------------------------
        public string PasswordHash { get; set; } = string.Empty;

        // ----------------------------
        // 🧩 Função ou perfil do usuário
        // Ex: Admin, User, Technician
        // ----------------------------
        public UserRole Role { get; set; } = UserRole.User;

        // ----------------------------
        // 🗓️ Data de criação e atualização (auditoria)
        // ----------------------------
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
