using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class VoteMappings : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Votes");
            builder.HasKey("Id");
            builder.Property(x => x.CandidateId).HasColumnType("int");
            builder.Property(x => x.DatetimeVote).HasColumnType("datetime");
            builder.Property(x => x.Legend).HasColumnType("int");
        }
    }
}
