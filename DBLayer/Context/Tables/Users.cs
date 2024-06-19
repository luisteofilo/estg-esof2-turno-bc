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
            .HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.SentFriendshipRequests)
            .WithOne(fr => fr.Requester)
            .HasForeignKey(fr => fr.RequesterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ReceivedFriendshipRequests)
            .WithOne(fr => fr.Receiver)
            .HasForeignKey(fr => fr.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Friendships1)
            .WithOne(f => f.User1)
            .HasForeignKey(f => f.UserId1)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Friendships2)
            .WithOne(f => f.User2)
            .HasForeignKey(f => f.UserId2)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .Property(p => p.UserId)
            .HasDefaultValueSql("gen_random_uuid()");
    }
}