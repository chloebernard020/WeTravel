using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class WeTravelContext : DbContext
{
    public DbSet<Appreciation> Appreciations { get; set; } = null!;
    public DbSet<Compte> Comptes { get; set; } = null!;
    public DbSet<Amitie> Amities { get; set; } = null!;
    public DbSet<Continent> Continents { get; set; } = null!;
    public DbSet<Culture> Cultures { get; set; } = null!;
    public DbSet<Lieu> Lieux { get; set; } = null!;
    public DbSet<Pays> Pays { get; set; } = null!;
    public DbSet<Ville> Villes { get; set; } = null!;
    public DbSet<Visite> Visites { get; set; } = null!;
    public DbSet<Favori> Favoris { get; set; } = null!;
    public DbSet<Photo> Photos { get; set; } = null!;

    public string DbPath { get; private set; }

    public WeTravelContext()
    {
        // Path to SQLite database file
        DbPath = "WeTravel.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}
