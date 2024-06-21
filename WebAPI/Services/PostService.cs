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

    public List<ResponsePostDto> GetAllPosts()
    {
        try
        {
            return _context.Posts.Select(p => new ResponsePostDto
            {
                PostId = p.PostId,
                Text = p.Text,
                CreatorId = p.CreatorId,
                DateTimePost = p.DateTimePost
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.", ex);
        }
    }

    public ResponsePostDto GetPostById(Guid id)
    {
        var post = _context.Posts.Find(id);
        if (post == null)
            throw new ArgumentException("Post not found.");
        
        return new ResponsePostDto
        {
            PostId = post.PostId,
            Text = post.Text,
            CreatorId = post.CreatorId,
            DateTimePost = post.DateTimePost
        };
    }

    public ResponsePostDto CreatePost(CreatePostDto createPostDto)
    {
        try
        {
            var post = new Post
            {
                Text = createPostDto.Text,
                CreatorId = createPostDto.CreatorId
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            return new ResponsePostDto
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

    public ResponsePostDto UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = _context.Posts.Find(id);

        if (post == null)
            throw new ArgumentException("Post not found.");
        
        post.Text = updatePostDto.Text?? post.Text;

        _context.SaveChanges();

        return new ResponsePostDto
        {
            PostId = post.PostId,
            Text = post.Text,
            CreatorId = post.CreatorId,
            DateTimePost = post.DateTimePost
        };
    }

    public void DeletePost(Guid id)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var post = _context.Posts.Find(id);

                if (post== null)
                    throw new ArgumentException("Post not found.");

                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }
}