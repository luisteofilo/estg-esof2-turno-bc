using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildTasteQuestionsType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasteQuestionsType>(entity =>
        {
            entity.HasKey(tqt => tqt.TasteQuestionsTypeId);

            entity.Property(tqt => tqt.TasteQuestionsTypeId)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(tqt => tqt.Type)
                .IsRequired();
        });
    }
}