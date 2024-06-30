using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteEvaluations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteEvaluation>(entity =>
        {
            entity.Property(p => p.TasteEvaluationId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(te => te.User)
                .WithMany()
                .HasForeignKey(te => te.UserId);

            entity.HasOne(te => te.Wine)
                .WithMany()
                .HasForeignKey(te => te.WineId);

            entity.HasOne(te => te.Event)
                .WithMany()
                .HasForeignKey(te => te.EventId);
        });
    }
}