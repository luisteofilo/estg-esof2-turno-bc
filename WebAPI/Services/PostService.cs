using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebAPI.DtoClasses;

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
            var posts = await _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Select(p => new FeedPostDto
                {
                    PostId = p.PostId,
                    Text = p.Text,
                    CreatorId = p.CreatorId,
                    Creator = new FeedPostUserDto
                    {
                        UserId = p.Creator.UserId,
                        Email = p.Creator.Email
                    },
                    DateTimePost = p.DateTimePost,
                    VisibilityType = p.VisibilityType,
                    LikeCount = p.Likes.Count(l => l.IsActive),
                    IsLiked = false,  
                    Likes = p.Likes.Where(l => l.IsActive).Select(l => new FeedPostUserDto
                    {
                        UserId = l.UserId,
                        Email = l.User.Email
                    }).ToList(),
                    CommentCount = p.Comments.Count,
                    Comments = p.Comments.Select(c => new FeedPostCommentDto
                    {
                        CommentId = c.CommentId,
                        PostId = c.PostId,
                        UserId = c.UserId,
                        Content = c.Content,
                        CreatedAt = c.CreatedAt,
                        UpdatedAt = c.UpdatedAt,
                        User = new FeedPostUserDto
                        {
                            UserId = c.User.UserId,
                            Email = c.User.Email
                        }
                    }).ToList()
                }).ToListAsync();

            return posts;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.", ex);
        }
    }
    public async Task<FeedPostDto> GetPostById(Guid postId)
    {
        var post = await _context.Posts
            .Include(p => p.Creator)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.PostId == postId);

        if (post == null)
            throw new ArgumentException("Post not found.");


        var postDto = new FeedPostDto
        {
            PostId = post.PostId,
            Text = post.Text,
            CreatorId = post.CreatorId,
            Creator = new FeedPostUserDto
            {
                UserId = post.Creator.UserId,
                Email = post.Creator.Email
            },
            DateTimePost = post.DateTimePost,
            VisibilityType = post.VisibilityType,
            LikeCount = post.Likes.Count(l => l.IsActive),
            IsLiked = false, // Not checking for a specific user
            Likes = post.Likes.Where(l => l.IsActive).Select(l => new FeedPostUserDto
            {
                UserId = l.UserId,
                Email = l.User.Email
            }).ToList(),
            CommentCount = post.Comments.Count,
            Comments = post.Comments.Select(c => new FeedPostCommentDto
            {
                CommentId = c.CommentId,
                PostId = c.PostId,
                UserId = c.UserId,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                User = new FeedPostUserDto
                {
                    UserId = c.User.UserId,
                    Email = c.User.Email
                }
            }).ToList()
        };

        return postDto;
    }

    public async Task<FeedPostDto> CreatePost(CreateFeedPostDto createFeedPostDto)
    {
        try
        {
            var post = new Post
            {
                Text = createFeedPostDto.Text,
                CreatorId = createFeedPostDto.CreatorId,
                DateTimePost = DateTimeOffset.UtcNow,
                VisibilityType = createFeedPostDto.VisibilityType
            };
            
            if (createFeedPostDto.Media is not null)
            {
                foreach (var m in createFeedPostDto.Media)
                {
                    var media = new PostMedia()
                    {
                        Data = m.Data,
                        FileExtension = m.FileExtension,
                        Filename = m.Filename,
                        MediaPostId = post.PostId,
                    };
                    _context.PostMedia.Add(media);
                }
            }

            post.PostWineId = createFeedPostDto.WineId;
            post.PostEventId = createFeedPostDto.EventId;
            
            _context.Posts.Add(post);
            
            await _context.SaveChangesAsync();

            return new FeedPostDto
            {
                PostId = post.PostId,
                Text = post.Text,
                CreatorId = post.CreatorId,
                DateTimePost = post.DateTimePost,
                VisibilityType = post.VisibilityType
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
            DateTimePost = post.DateTimePost,
            VisibilityType = post.VisibilityType
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