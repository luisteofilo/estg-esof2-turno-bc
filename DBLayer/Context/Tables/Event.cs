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
        
        modelBuilder.Entity<Event>()
            .Property(e => e.Description) 
            .HasMaxLength(1000);
        

        modelBuilder.Entity<Event>()
            .Property(e => e.BlindTasting) 
            .IsRequired();

        modelBuilder.Entity<Event>()
            .Property(e => e.WineType) 
            .HasMaxLength(255);

        modelBuilder.Entity<Event>().HasData(
            new Event { EventId = Guid.NewGuid(), Name = "Event1", Slug = "event1", Description = "Description for Event 1", BlindTasting = false, WineType = "Red"},
            new Event { EventId = Guid.NewGuid(), Name = "Event2", Slug = "event2", Description = "Description for Event 2", BlindTasting = true, WineType = "White"},
            new Event { EventId = Guid.NewGuid(), Name = "Event3", Slug = "event3", Description = "Description for Event 3", BlindTasting = true, WineType = "Sparkling"},
            new Event { EventId = Guid.NewGuid(), Name = "Event4", Slug = "event4", Description = "Description for Event 4", BlindTasting = false, WineType = "Rose"},
            new Event { EventId = Guid.NewGuid(), Name = "Event5", Slug = "event5", Description = "Description for Event 5", BlindTasting = false, WineType = "Desset"}
        );

    }
}
