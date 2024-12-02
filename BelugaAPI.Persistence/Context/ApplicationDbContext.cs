using BelugaAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelugaAPI.Persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Video> Video { get; set; }
    public DbSet<AccessKey> AccessKey { get; set; }
    public DbSet<Translation> Translation { get; set; }
    public DbSet<Chat> Chat { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql("Host=beluga-db.postgres.database.azure.com;Port=5432;Username=admin_beluga;Password=Beluga12345;Database=core");
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da chave composta na entidade Chat
        modelBuilder.Entity<Chat>()
            .HasKey(c => new { c.userId, c.videoId });

        // Configuração do relacionamento entre Chat e User
        modelBuilder.Entity<Chat>()
            .HasOne(c => c.user)
            .WithMany(u => u.chats) // Propriedade de navegação (se existir)
            .HasForeignKey(c => c.userId);

        // Configuração do relacionamento entre Chat e Video
        modelBuilder.Entity<Chat>()
            .HasOne(c => c.video)
            .WithMany(v => v.chats) // Propriedade de navegação (se existir)
            .HasForeignKey(c => c.videoId);

    }
}
