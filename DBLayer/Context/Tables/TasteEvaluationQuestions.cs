using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteEvaluationQuestion(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteEvaluationQuestion>(entity =>
        {
            entity.HasKey(teq => teq.TasteEvaluationQuestionId);

            entity.Property(teq => teq.TasteEvaluationQuestionId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(teq => teq.TasteEvaluation)
                .WithMany(te => te.TasteEvaluationQuestions)
                .HasForeignKey(teq => teq.TasteEvaluationId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(teq => teq.TasteQuestion)
                .WithMany(tq => tq.TasteEvaluationQuestions)
                .HasForeignKey(teq => teq.TasteQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(teq => teq.Value)
                .IsRequired();
        });
    }
}