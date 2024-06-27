using Microsoft.EntityFrameworkCore;
using Votes.Models;

namespace Votes.Data
{
    public class VoteContext : DbContext
    {
        public VoteContext()
        {
            
        }
        public virtual DbSet<Voter> TbVotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5S281L7;Database=Votes;Trusted_Connection=True;TrustServerCertificate=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voter>(entity =>
            {
                entity.Property(a => a.Age).HasMaxLength(60);
            });
        }
    }
}
