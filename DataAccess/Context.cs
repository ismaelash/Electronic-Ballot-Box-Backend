using DataAccess.Mappings;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.GET_CONNECTION_STRING());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CandidateMappings());
            builder.ApplyConfiguration(new VoteMappings());
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Vote> Vote { get; set; }

    }
}