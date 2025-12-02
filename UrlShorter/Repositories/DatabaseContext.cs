using Microsoft.EntityFrameworkCore;
using UrlShorter.Models;

namespace UrlShorter.Repositories;

public sealed class DatabaseContext: DbContext
{
    /// <summary>
    /// Ячейки
    /// </summary>
    public DbSet<ShortUrls> ShortUrls { get; set; }
    

    public DatabaseContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=6432;Database=postgres;Username=postgres;Password=postgres");
    }
}