using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildVinho(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vinho>(entity =>
        {
            entity.HasKey(e => e.VinhoId);

            entity.Property(e => e.Name)
                .IsRequired();

            entity.Property(e => e.Tipo)
                .IsRequired();

            entity.Property(e => e.VinhoId)
                .HasDefaultValueSql("gen_random_uuid()");
        });
    }
}