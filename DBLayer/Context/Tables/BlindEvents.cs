using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        private void BuildBlindEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlindEvent>()
                .Property(p => p.BlindEventId)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<BlindEvent>()
                .HasOne(be => be.Organizer)
                .WithMany(u => u.OrganizedEvents)
                .HasForeignKey(be => be.OrganizerId);

            modelBuilder.Entity<BlindEvent>()
                .HasMany(be => be.Participants)
                .WithOne(p => p.BlindEvent)
                .HasForeignKey(p => p.BlindEventId);
        }
    }
}
