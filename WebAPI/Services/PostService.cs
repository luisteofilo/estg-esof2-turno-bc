using ESOF.WebApp.WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;
using Microsoft.EntityFrameworkCore;

public class PostService
{
    private readonly ApplicationDbContext _context;

    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<FeedPostDto>> GetAllPosts()
    {
        try
        {
            return await _context.Posts.Select(p => new FeedPostDto
            {
                PostId = p.PostId,
                Text = p.Text,
                CreatorId = p.CreatorId,
                DateTimePost = p.DateTimePost
            }).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.", ex);
        }
    }

    public async Task<FeedPostDto> GetPostById(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            throw new ArgumentException("Post not found.");
        
        return new FeedPostDto
        {
            PostId = post.PostId,
            Text = post.Text,
            CreatorId = post.CreatorId,
            DateTimePost = post.DateTimePost
        };
    }

    public async Task<FeedPostDto> CreatePost(CreateFeedPostDto createFeedPostDto)
    {
        try
        {
            var post = new Post
            {
                Text = createFeedPostDto.Text,
                CreatorId = createFeedPostDto.CreatorId,
                DateTimePost = DateTimeOffset.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new FeedPostDto
            {
                PostId = post.PostId,
                Text = post.Text,
                CreatorId = post.CreatorId,
                DateTimePost = post.DateTimePost
            };
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while creating the post.", ex);
        }
    }

    public async Task<FeedPostDto> UpdatePost(Guid id, FeedPostDto updatePostDto)
    {
        var post = _context.Posts.Find(id);

        if (post == null)
            throw new ArgumentException("Post not found.");
        
        post.Text = updatePostDto.Text?? post.Text;

        await _context.SaveChangesAsync();

        return new FeedPostDto
        {
            PostId = post.PostId,
            Text = post.Text,
            CreatorId = post.CreatorId,
            DateTimePost = post.DateTimePost
        };
    }

    public async Task DeletePost(Guid id)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var post = _context.Posts.Find(id);

                if (post== null)
                    throw new ArgumentException("Post not found.");

                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
        }
    }
}