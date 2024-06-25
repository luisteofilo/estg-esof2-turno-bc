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
            entity.HasKey(tq => tq.TasteQuestionId);

            entity.Property(tq => tq.TasteQuestionId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(tq => tq.Questions)
                .IsRequired();

            entity.HasOne(tq => tq.QuestionType)
                .WithMany(qt => qt.TasteQuestions)
                .HasForeignKey(tq => tq.QuestionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(tq => tq.Event)
                .WithMany(e => e.TasteQuestions)
                .HasForeignKey(tq => tq.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(tq => tq.TasteEvaluationQuestions)
                .WithOne(teq => teq.TasteQuestion)
                .HasForeignKey(teq => teq.TasteQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

}