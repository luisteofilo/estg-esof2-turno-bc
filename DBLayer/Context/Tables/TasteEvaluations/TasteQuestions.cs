using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteQuestions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteQuestion>(entity =>
        {
            entity.Property(p => p.TasteQuestionId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(te => te.TasteQuestionType)
                .WithMany()
                .HasForeignKey(te => te.TasteQuestionTypeId);

            entity.HasOne(te => te.Event)
                .WithMany()
                .HasForeignKey(te => te.EventId);
        });
    }
}