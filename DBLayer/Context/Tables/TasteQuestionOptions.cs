using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteQuestionOptions(ModelBuilder modelBuilder)
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

            entity.HasMany(tq => tq.Options) 
                .WithOne(to => to.TasteQuestion)
                .HasForeignKey(to => to.TasteQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TasteQuestionOption>(entity =>
        {
            entity.HasKey(tqo => tqo.TasteQuestionOptionId);

            entity.Property(tqo => tqo.TasteQuestionOptionId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(tqo => tqo.OptionText)
                .IsRequired();

            entity.HasOne(tqo => tqo.TasteQuestion)
                .WithMany(tq => tq.Options)
                .HasForeignKey(tqo => tqo.TasteQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
