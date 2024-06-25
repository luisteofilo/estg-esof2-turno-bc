using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{

    private void BuildWineGrapeTypeLinks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WineGrapeTypeLink>()
            .HasOne(wgt => wgt.Wine)
            .WithMany(w => w.WineGrapeTypeLinks)
            .HasForeignKey(wgt => wgt.WineId)
            .IsRequired(false); 

        modelBuilder.Entity<WineGrapeTypeLink>()
            .HasOne(wgt => wgt.GrapeType)
            .WithMany(gt => gt.WineGrapeTypes)
            .HasForeignKey(wgt => wgt.GrapeTypeId)
            .IsRequired(false); 
    }
}