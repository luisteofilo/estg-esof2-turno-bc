using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        private void BuildParticipantWines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantWine>()
                .Property(pw => pw.ParticipantWineId)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<ParticipantWine>()
                .HasOne(pw => pw.Participant)
                .WithMany(p => p.ParticipantWines)
                .HasForeignKey(pw => pw.ParticipantId);

            modelBuilder.Entity<ParticipantWine>()
                .HasOne(pw => pw.Wine)
                .WithMany(w => w.ParticipantWines)
                .HasForeignKey(pw => pw.WineId);

            modelBuilder.Entity<ParticipantWine>()
                .HasOne(pw => pw.BlindEvent)
                .WithMany(be => be.ParticipantWines)
                .HasForeignKey(pw => pw.BlindEventId);

            modelBuilder.Entity<ParticipantWine>()
                .HasIndex(pw => new { pw.WineId, pw.BlindEventId })
                .IsUnique();
        }
    }
}