using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        private void BuildParticipants(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .Property(p => p.ParticipantId)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.User)
                .WithMany(u => u.Participants)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Participant>()
                .HasOne(p => p.BlindEvent)
                .WithMany(be => be.Participants)
                .HasForeignKey(p => p.BlindEventId);
            
            modelBuilder.Entity<Participant>()
                .HasIndex(p => new { p.UserId, p.BlindEventId })
                .IsUnique();
        }
    }

}
    
