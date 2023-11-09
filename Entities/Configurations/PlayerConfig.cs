using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeams.Entities.Configurations;

public class PlayerConfig : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Salary).IsRequired();
        builder.Property(x => x.JerseyNumber).IsRequired();
        builder.Property(x => x.Position).IsRequired();
        builder.Property(x => x.TeamId).IsRequired();
    }
}
