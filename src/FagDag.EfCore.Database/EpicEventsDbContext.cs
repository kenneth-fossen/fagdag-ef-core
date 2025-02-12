using Microsoft.EntityFrameworkCore;

namespace FagDag.EfCore.Database;

public class EpicEventsDbContext(DbContextOptions<EpicEventsDbContext> options) : DbContext(options)
{
    private static string DbPath { get => "EpicEvents.db"; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
