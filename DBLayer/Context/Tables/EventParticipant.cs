using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildEventParticipants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventParticipant>()
            .HasKey(ep => ep.EventParticipantId);

        modelBuilder.Entity<EventParticipant>()
            .Property(ep => ep.EventParticipantId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<EventParticipant>()
            .HasOne(ep => ep.Event)
            .WithMany(e => e.EventParticipants)
            .HasForeignKey(ep => ep.EventId);

        modelBuilder.Entity<EventParticipant>()
            .HasOne(ep => ep.User)
            .WithMany(u => u.EventParticipants)
            .HasForeignKey(ep => ep.UserId);
    }
}
