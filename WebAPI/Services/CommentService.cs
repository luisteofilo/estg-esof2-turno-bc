using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class CommentService
{
    private readonly ApplicationDbContext _context;

    public CommentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateCommentAsync(Guid postId, Guid userId, string content)
    {
        var comment = new Comment
        {
            CommentId = Guid.NewGuid(),
            PostId = postId,
            UserId = userId,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task<Comment> EditCommentAsync(Guid commentId, string newContent)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        if (comment == null)
        {
            throw new CommentNotFoundException("Comment not found");
        }

        comment.Content = newContent;
        comment.UpdatedAt = DateTime.UtcNow;

        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task DeleteCommentAsync(Guid commentId)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        if (comment == null)
        {
            throw new CommentNotFoundException("Comment not found");
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CommentDto>> GetCommentsForPostAsync(Guid postId)
    {
        return await _context.Comments
            .Where(c => c.PostId == postId)
            .Select(c => new CommentDto
            {
                CommentId = c.CommentId,
                PostId = c.PostId,
                UserId = c.UserId,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                UserName = c.User
                    .UserName 
            })
            .ToListAsync();
    }

    public async Task<int> GetCommentCountForPostAsync(Guid postId)
    {
        return await _context.Comments
            .CountAsync(c => c.PostId == postId);
    }
}

public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(string message) : base(message)
        {
        }
    }