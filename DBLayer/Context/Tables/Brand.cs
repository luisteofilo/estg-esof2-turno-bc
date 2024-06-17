using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildBrands(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>()
            .Property(p => p.BrandId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Brand>()
            .HasMany(b => b.Wines)
            .WithOne(w => w.Brand)
            .HasForeignKey(w => w.BrandId);

    }
}