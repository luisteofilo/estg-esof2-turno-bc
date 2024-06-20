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

        _context.Friendships.Remove(friendship);
        await _context.SaveChangesAsync();
    }
}

// Custom exception for friendship not found
public class FriendshipNotFoundException : Exception
{
    public FriendshipNotFoundException(string message) : base(message)
    {
    }
}