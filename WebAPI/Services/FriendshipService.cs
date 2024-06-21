using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class FriendshipService
{
    private readonly ApplicationDbContext _context;

    public FriendshipService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetFriendsForUserAsync(Guid userId)
    {
        var friends = await _context.Friendships
            .Where(f => f.UserId1 == userId || f.UserId2 == userId)
            .Select(f => f.UserId1 == userId ? f.User2 : f.User1)
            .ToListAsync();

        return friends;
    }
        
    public async Task RemoveFriendAsync(Guid userId1, Guid userId2)
    {
        var friendship = await _context.Friendships
            .FirstOrDefaultAsync(f => (f.UserId1 == userId1 && f.UserId2 == userId2) || (f.UserId1 == userId2 && f.UserId2 == userId1));

        if (friendship == null)
            throw new FriendshipNotFoundException("Friendship not found");

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                // Remove the friendship
                _context.Friendships.Remove(friendship);

                // Decrement friends count for both users
                var requester = await _context.Users.FindAsync(userId1);
                var receiver = await _context.Users.FindAsync(userId2);

                if (requester != null)
                {
                    requester.FriendsCount--;
                }

                if (receiver != null)
                {
                    receiver.FriendsCount--;
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

}

public class FriendshipNotFoundException : Exception
{
    public FriendshipNotFoundException(string message) : base(message)
    {
    }
}