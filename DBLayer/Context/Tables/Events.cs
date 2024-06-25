using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context
{
    public partial class ApplicationDbContext
    {
        private void BuildEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.EventId)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Event>()
                .HasMany<Wine>(e => e.Wines)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany<Participant>(e => e.Participants)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}