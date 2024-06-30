using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace ESOF.WebApp.DBLayer.Context;

public partial class ApplicationDbContext
{
    private void BuildFriendRequests(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FriendRequest>()
            .HasKey(fr => fr.RequestId);

        modelBuilder.Entity<FriendRequest>()
            .HasOne(fr => fr.Requester)
            .WithMany(u => u.SentFriendshipRequests)
            .HasForeignKey(fr => fr.RequesterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FriendRequest>()
            .HasOne(fr => fr.Receiver)
            .WithMany(u => u.ReceivedFriendshipRequests)
            .HasForeignKey(fr => fr.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FriendRequest>()
            .Property(fr => fr.Status)
            .HasConversion(
                v => v.ToString(),
                v => (FriendRequestState)Enum.Parse(typeof(FriendRequestState), v))
            .HasColumnType("text")
            .IsRequired();
    }
}