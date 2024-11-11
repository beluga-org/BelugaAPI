using BelugaAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelugaAPI.Persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Video> Video { get; set; }
    public DbSet<AccessKey> AccessKey { get; set; }
    public DbSet<Translation> Translation { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=password;Database=postgres");
    }
}