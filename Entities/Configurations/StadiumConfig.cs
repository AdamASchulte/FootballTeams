using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeams.Entities.Configurations;

public class StadiumConfig : IEntityTypeConfiguration<Stadium>
{
    public void Configure(EntityTypeBuilder<Stadium> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MaxCapacity).IsRequired();
    }
}
