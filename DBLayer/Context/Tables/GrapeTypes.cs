using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildGrapeTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GrapeType>()
            .Property(p => p.GrapeTypeId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        modelBuilder.Entity<GrapeType>()
            .HasMany(gt => gt.WineGrapeTypes)
            .WithOne(wgt => wgt.GrapeType)
            .HasForeignKey(wgt => wgt.GrapeTypeId);
    }
}