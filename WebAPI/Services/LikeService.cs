using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;
public class LikeService
{
    private readonly ApplicationDbContext _context;

    public LikeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Like> ToggleLikeAsync(Guid postId, Guid userId)
    {
        var like = await _context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);

        if (like == null)
        {
            like = new Like
            {
                LikeId = Guid.NewGuid(),
                PostId = postId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            _context.Likes.Add(like);
        }
        else
        {
            like.IsActive = !like.IsActive;
            _context.Likes.Update(like);
        }

        await _context.SaveChangesAsync();
        return like;
    }

    public async Task<List<Like>> GetLikesForPostAsync(Guid postId)
    {
        return await _context.Likes
            .Where(l => l.PostId == postId && l.IsActive)
            .ToListAsync();
    }

    public async Task<int> GetLikeCountForPostAsync(Guid postId)
    {
        return await _context.Likes
            .CountAsync(l => l.PostId == postId && l.IsActive);
    }
    
    public async Task<bool> IsPostLikedByUserAsync(Guid postId, Guid userId)
    {
        return await _context.Likes
            .AnyAsync(l => l.PostId == postId && l.UserId == userId && l.IsActive);
    }

}