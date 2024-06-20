using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildWines(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wine>()
            .Property(p => p.WineId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        modelBuilder.Entity<Wine>()
            .HasMany(w => w.WineGrapeTypeLinks)
            .WithOne(wgt => wgt.Wine)
            .HasForeignKey(wgt => wgt.WineId)
            .IsRequired(false);
        
        modelBuilder.Entity<Wine>()
            .HasOne(w => w.Brand)
            .WithMany(b => b.Wines)
            .HasForeignKey(w => w.BrandId)
            .IsRequired(false);

        modelBuilder.Entity<Wine>()
            .HasOne(w => w.Region)
            .WithMany(r => r.Wines)
            .HasForeignKey(w => w.RegionId)
            .IsRequired(false);
    }
}