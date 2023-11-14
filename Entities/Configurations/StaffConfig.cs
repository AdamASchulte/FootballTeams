using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeams.Entities.Configurations;

internal class StaffConfig : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OffensiveCoordinator).IsRequired();
        builder.Property(x => x.DefensiveCoordinator).IsRequired();
        builder.Property(x => x.SpecialTeamsCoordinator).IsRequired();
        builder.Property(x => x.HeadCoach).IsRequired();
    }
}
