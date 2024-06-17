using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildWineGrapeTypeLinks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WineGrapeTypeLink>()
            .Property(p => p.WineGrapeTypeLinkId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<WineGrapeTypeLink>()
            .HasOne(wgt => wgt.Wine)
            .WithMany(w => w.WineGrapeTypeLinks)
            .HasForeignKey(wgt => wgt.WineId);
    }
}