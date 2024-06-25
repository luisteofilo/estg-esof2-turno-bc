﻿using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.AspNetCore.Mvc.Formatters;

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
            var posts = await _context.Posts.Select(p => new FeedPostDto
            {
                PostId = p.PostId,
                Text = p.Text,
                CreatorId = p.CreatorId,
                DateTimePost = p.DateTimePost,
                VisibilityType = p.VisibilityType
            }).ToListAsync();

            foreach (var p in posts)
            {
                var creator = await _context.Users.FindAsync(p.CreatorId);
                p.Creator = new FeedPostUserDto()
                {
                    UserId = creator.UserId,
                    Email = creator.Email
                };
            }
            
            return posts;
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

        var postDto = new FeedPostDto
        {
            PostId = post.PostId,
            Text = post.Text,
            CreatorId = post.CreatorId,
            DateTimePost = post.DateTimePost,
            VisibilityType = post.VisibilityType,
        };
        
        var creator = await _context.Users.FindAsync(postDto.CreatorId);
        postDto.Creator = new FeedPostUserDto()
        {
            UserId = creator.UserId,
            Email = creator.Email
        };
        
        var media = await _context.PostMedia
            .Where(m => 
                m.MediaPostId == post.PostId)
            .ToListAsync();
        
        var mediaDto = new List<FeedPostMediaDto>();
        
        foreach (var m in media)
        {
            mediaDto.Add(new FeedPostMediaDto()
            {
                MediaId = m.MediaId,
                Data = m.Data,
                FileExtension = m.FileExtension,
                Filename = m.Filename,
                MediaPostId = postDto.PostId
            });
        }
        
        postDto.Media = mediaDto;

        var hashtags = await _context.Hashtags
            .Where(h =>
                h.Posts.Any(p =>
                    p.PostId == postDto.PostId))
            .ToListAsync();
        
        var hashtagsDto = new List<FeedPostHashtagDto>();
        
        foreach (var h in hashtags)
        {
            hashtagsDto.Add(new FeedPostHashtagDto()
            {
                HashtagId = h.HashtagId,
                Name = h.Name,
                NumPosts = h.NumPosts
            });
        }

        postDto.Hashtags = hashtagsDto;
        
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
            _context.Posts.Add(post);
            
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