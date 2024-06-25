using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildParticipants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participant>()
            .Property(p => p.ParticipantId)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Participant>()
            .HasIndex(p => p.Email)
            .IsUnique();
    }
}