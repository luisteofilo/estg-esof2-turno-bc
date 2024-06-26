using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteEvaluationQuestions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteEvaluationQuestion>(entity =>
        {
            entity.Property(p => p.TasteEvaluationQuestionId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(te => te.TasteEvaluation)
                .WithMany()
                .HasForeignKey(te => te.TasteEvaluationId);

            entity.HasOne(te => te.TasteQuestion)
                .WithMany()
                .HasForeignKey(te => te.TasteQuestionId);
        });
    }
}