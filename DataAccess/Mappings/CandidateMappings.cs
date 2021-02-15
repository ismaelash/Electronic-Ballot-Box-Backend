using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class CandidateMappings : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates");
            builder.HasKey("Id");
            builder.Property(x => x.NameCandidate).IsRequired().HasColumnType("varchar(255)");
            builder.Property(x => x.NameViceCandidate).IsRequired().HasColumnType("varchar(255)");
            builder.Property(x => x.DataCreation).HasColumnType("datetime");
            builder.Property(x => x.Legend).IsRequired().HasColumnType("int");
            builder.Property(x => x.Image).HasColumnType("varchar(255)");
            builder.Property(x => x.IsEnable).HasColumnType("bit");
        }
    }
}
