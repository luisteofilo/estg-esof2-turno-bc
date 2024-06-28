using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext : DbContext
    {


        private void BuildEvaluations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>()
                .Property(e => e.EvaluationId)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Participant)
                .WithMany(p => p.Evaluations)
                .HasForeignKey(e => e.ParticipantId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Wine)
                .WithMany(w => w.Evaluations)
                .HasForeignKey(e => e.WineId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.BlindEvent)
                .WithMany(be => be.Evaluations)
                .HasForeignKey(e => e.BlindEventId);
        }
    }
}
