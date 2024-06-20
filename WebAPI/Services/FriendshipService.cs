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
        var friends1 = await _context.Friendships
            .Where(f => f.UserId1 == userId)
            .Select(f => f.User2)
            .ToListAsync();

        var friends2 = await _context.Friendships
            .Where(f => f.UserId2 == userId)
            .Select(f => f.User1)
            .ToListAsync();

        return friends1.Concat(friends2).ToList();
    }
    
    public bool RemoveFriend(Guid userId1, Guid userId2)
    {
        var friendship = _context.Friendships
            .FirstOrDefault(f => (f.UserId1 == userId1 && f.UserId2 == userId2) || (f.UserId1 == userId2 && f.UserId2 == userId1));

        if (friendship == null)
            return false;

        _context.Friendships.Remove(friendship);
        _context.SaveChanges();
        return true;
    }
}