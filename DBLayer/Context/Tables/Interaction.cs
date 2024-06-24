using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext
    {
        private void BuildInteraction(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.User)
                .WithMany(u => u.Interactions)
                .HasForeignKey(i => i.UserId)
                .IsRequired(false); 
            
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.Wine)
                .WithMany(w => w.WineInteractions)
                .HasForeignKey(i => i.WineId)
                .IsRequired(false); 
        }
    }
}