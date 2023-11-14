using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeams.Entities.Configurations;

internal class TeamStatsConfig : IEntityTypeConfiguration<TeamStats>
{
    public void Configure(EntityTypeBuilder<TeamStats> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Wins).IsRequired();
        builder.Property(x => x.Losses).IsRequired();
    }
}
