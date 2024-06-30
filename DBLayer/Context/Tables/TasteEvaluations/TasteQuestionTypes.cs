using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteQuestionTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteQuestionType>(entity =>
        {
            entity.Property(p => p.TasteQuestionTypeId)
                .HasDefaultValueSql("gen_random_uuid()");
        });
    }
}