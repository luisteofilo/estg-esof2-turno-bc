using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildEvent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasKey(e => e.EventId);

        modelBuilder.Entity<Event>()
            .Property(e => e.EventId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Event>()
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        modelBuilder.Entity<Event>()
            .Property(e => e.Slug)
            .IsRequired()
            .HasMaxLength(255);

        modelBuilder.Entity<Event>()
            .HasMany(e => e.EventParticipants)
            .WithOne(ep => ep.Event)
            .HasForeignKey(ep => ep.EventId);

        modelBuilder.Entity<Event>().HasData(
            new Event { EventId = Guid.NewGuid(), Name = "Event1", Slug = "event1" },
            new Event { EventId = Guid.NewGuid(), Name = "Event2", Slug = "event2" },
            new Event { EventId = Guid.NewGuid(), Name = "Event3", Slug = "event3" },
            new Event { EventId = Guid.NewGuid(), Name = "Event4", Slug = "event4" },
            new Event { EventId = Guid.NewGuid(), Name = "Event5", Slug = "event5" }
        );
    }
}