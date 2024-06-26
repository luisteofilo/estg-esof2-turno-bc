using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildFriendships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Friendship>()
            .HasKey(f => f.FriendshipId);

        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.User1)
            .WithMany(u => u.Friendships1)
            .HasForeignKey(f => f.UserId1)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.User2)
            .WithMany(u => u.Friendships2)
            .HasForeignKey(f => f.UserId2)
            .OnDelete(DeleteBehavior.Cascade);
    }
}