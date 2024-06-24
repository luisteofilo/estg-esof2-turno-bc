using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Interaction = Microsoft.VisualBasic.Interaction;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext
    {
        private void BuildInteraction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.User)
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
}