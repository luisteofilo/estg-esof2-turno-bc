using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildWineComments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WineComment>()
            .Property(wc => wc.WineCommentId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<WineComment>()
            .HasOne(wc => wc.User)
            .WithMany(u => u.WineComments)
            .HasForeignKey(wc => wc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<WineComment>()
            .HasOne(wc => wc.Wine)
            .WithMany(w => w.WineComments)
            .HasForeignKey(wc => wc.WineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}