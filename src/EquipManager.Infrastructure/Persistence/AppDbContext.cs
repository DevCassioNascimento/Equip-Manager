using EquipManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipManager.Infrastructure.Persistence
{
    // O DbContext representa a ponte entre o domínio e o banco de dados.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Cada DbSet vira uma tabela no banco
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui adicionaremos configurações personalizadas no futuro
        }
    }
}

