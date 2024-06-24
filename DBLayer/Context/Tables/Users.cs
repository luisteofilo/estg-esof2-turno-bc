using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.OrganizedEvents)
            .WithOne(be => be.Organizer)
            .HasForeignKey(be => be.OrganizerId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Participants)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .Property(p => p.UserId)
            .HasDefaultValueSql("gen_random_uuid()");
    }
}