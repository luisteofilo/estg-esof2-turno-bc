using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildRegions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>()
            .Property(p => p.RegionId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        modelBuilder.Entity<Region>()
            .HasMany(r => r.Wines)
            .WithOne(w => w.Region)
            .HasForeignKey(w => w.RegionId);
        
    }
}