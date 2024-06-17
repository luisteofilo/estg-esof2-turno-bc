using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteEvaluations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteEvaluation>(entity =>
        {
            entity.HasKey(te => te.TasteEvaluationId);

            entity.Property(te => te.TasteEvaluationId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(te => te.User)
                .WithMany(u => u.TasteEvaluations)
                .HasForeignKey(te => te.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(te => te.Wine)
                .WithMany(w => w.TasteEvaluations)
                .HasForeignKey(te => te.WineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(te => te.Event)
                .WithMany(e => e.TasteEvaluations)
                .HasForeignKey(te => te.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(te => te.WineScore)
                .IsRequired();
        });
    }
}