using FootballTeams.Entities;
using FootballTeams.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams;

internal class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source = FootballTeams.db");
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<TeamStats> TeamStats { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeamConfig());
        modelBuilder.ApplyConfiguration(new PlayerConfig());
        modelBuilder.ApplyConfiguration(new TeamStatsConfig());
        modelBuilder.ApplyConfiguration(new StaffConfig());
        modelBuilder.ApplyConfiguration(new StadiumConfig());
        modelBuilder.ApplyConfiguration(new LocationConfig());
        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        // Loop through all added entities
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
        {
            // Check if the entity has an Id property of type Guid and if it's empty
            if (entry.Properties.Any(prop => prop.Metadata.Name == "Id") &&
                (Guid)entry.Property("Id").CurrentValue == Guid.Empty)
            {
                // Generate a new random Guid and assign it to the Id property
                entry.Property("Id").CurrentValue = Guid.NewGuid();
            }
        }

        return base.SaveChanges();
    }
}
