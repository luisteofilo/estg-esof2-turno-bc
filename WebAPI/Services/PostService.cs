using System.Xml.Linq;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using DBLayer.Entities;
using DBLayer.Context;
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
                .Include(p => p.Media)
                .Include(p => p.Hashtags)
                .Include(p => p.Event)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Brand)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Region)
                .Select(p => new FeedPostDto
                {
                    PostId = p.PostId,
                    Text = p.Text,
                    CreatorId = p.CreatorId,
                    Creator = new FeedPostUserDto
                    {
                        UserId = p.Creator.UserId,
                        Email = p.Creator.Email,
                        UserName = p.Creator.UserName
                    },
                    DateTimePost = p.DateTimePost,
                    VisibilityType = p.VisibilityType,
                    LikeCount = p.Likes.Count(l => l.IsActive),
                    IsLiked = false,
                    Likes = p.Likes.Where(l => l.IsActive)
                        .Select(l => new FeedPostUserDto
                        {
                            UserId = l.UserId,
                            Email = l.User.Email
                        })
                        .ToList(),
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
                        })
                        .ToList(),
                    Media = p.Media.Select(m => new FeedPostMediaDto()
                        {
                            MediaId = m.MediaId,
                            Data = m.Data,
                            FileExtension = m.FileExtension,
                            Filename = m.Filename
                        })
                        .ToList(),
                    Hashtags = p.Hashtags.Select(h => new FeedPostHashtagDto()
                        {
                            HashtagId = h.HashtagId,
                            Name = h.Name
                        })
                        .ToList(),
                    PostEventId = p.PostEventId,
                    Event = p.Event != null
                        ? new ResponseEventDto()
                        {
                            EventId = p.Event.EventId,
                            Name = p.Event.Name,
                            Slug = p.Event.Slug
                        }
                        : null,
                    PostWineId = p.PostWineId,
                    Wine = p.Wine != null
                        ? new FeedPostWineDto()
                        {
                            WineId = p.Wine.WineId,
                            BrandId = p.Wine.BrandId,
                            Brand = new ResponseBrandDto()
                            {
                                BrandId = p.Wine.BrandId,
                                Name = p.Wine.Brand.Name,
                                Description = p.Wine.Brand.Description
                            },
                            RegionId = p.Wine.RegionId,
                            Region = new ResponseRegionDto()
                            {
                                RegionId = p.Wine.RegionId,
                                Name = p.Wine.Region.Name
                            },
                            Label = p.Wine.label,
                            LabelDesignation = p.Wine.LabelDesignation,
                            Category = p.Wine.category
                        }
                        : null
                }).OrderByDescending(p => p.DateTimePost)
                .ToListAsync();

            return posts;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.",
                ex);
        }
    }

    public async Task<List<FeedPostDto>> GetPostsByHashtagName(string hashtagName)
    {
        try
        {
            var postIds = _context.Hashtags
                .Where(h => h.Name == hashtagName)
                .SelectMany(h =>
                    h.Posts.Select(p => p.PostId))
                .ToList();

            var posts = _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Include(p => p.Media)
                .Include(p => p.Hashtags)
                .Include(p => p.Event)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Brand)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Region)
                .Where(p => postIds.Contains(p.PostId))
                .ToList();

            var postsDto = posts.Select(MapToFeedPostDto)
                .OrderByDescending(p => p.DateTimePost)
                .ToList();

            return postsDto;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.",
                ex);
        }
    }

    public async Task<List<FeedPostDto>> GetPostsByUserName(string userName)
    {
        try
        {
            var postIds = _context.Users
                .Where(u => u.UserName == userName)
                .SelectMany(u => 
                    u.Posts.Select(p => p.PostId))
                .ToList();

            var posts = _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Include(p => p.Media)
                .Include(p => p.Hashtags)
                .Include(p => p.Event)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Brand)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Region)
                .Where(p => postIds.Contains(p.PostId))
                .ToList();

            var postsDto = posts.Select(MapToFeedPostDto)
                .OrderByDescending(p => p.DateTimePost)
                .ToList();

            return postsDto;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.",
                ex);
        }
    }
    
    
    public async Task<List<FeedPostDto>> GetPostsByUserEmail(string userEmail)
    {
        try
        {
            var postIds = _context.Users
                .Where(u => u.Email == userEmail)
                .SelectMany(u => 
                    u.Posts.Select(p => p.PostId))
                .ToList();

            var posts = _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Include(p => p.Media)
                .Include(p => p.Hashtags)
                .Include(p => p.Event)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Brand)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Region)
                .Where(p => postIds.Contains(p.PostId))
                // .Where(p => p.Creator.Email == userEmail)
                .ToList();

            var postsDto = posts.Select(MapToFeedPostDto)
                .OrderByDescending(p => p.DateTimePost)
                .ToList();

            return postsDto;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.",
                ex);
        }
    }

    public async Task<List<FeedPostDto>> GetPostsByUserId(Guid userId)
    {
        try
        {
            var posts = _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Include(p => p.Media)
                .Include(p => p.Hashtags)
                .Include(p => p.Event)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Brand)
                .Include(p => p.Wine)
                .ThenInclude(w => w.Region)
                .Where(p => p.CreatorId == userId)
                .ToList();

            var postsDto = posts.Select(MapToFeedPostDto)
                .OrderByDescending(p => p.DateTimePost)
                .ToList();

            return postsDto;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving posts.",
                ex);
        }
    }

    
    private FeedPostDto MapToFeedPostDto(Post p)
    {
        var post = new FeedPostDto
        {
            PostId = p.PostId,
            Text = p.Text,
            CreatorId = p.CreatorId,
            Creator = p.Creator != null
                ? new FeedPostUserDto
                {
                    UserId = p.Creator.UserId,
                    Email = p.Creator.Email,
                    UserName = p.Creator.UserName
                }
                : null,
            DateTimePost = p.DateTimePost,
            VisibilityType = p.VisibilityType,
            Likes = p.Likes != null
                ? p.Likes.Where(l => l.IsActive)
                    .Select(l => new FeedPostUserDto
                    {
                        UserId = l.UserId,
                        Email = l.User.Email
                    })
                    .ToList()
                : null,
            LikeCount = p.Likes != null
                ? p.Likes.Count(l => l.IsActive)
                : 0,
            Comments = p.Comments != null
                ? p.Comments.Select(c => new FeedPostCommentDto
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
                    })
                    .ToList()
                : null,
            CommentCount = p.Comments != null 
                ? p.Comments.Count
                : 0,
            Media = p.Media != null
                ? p.Media.Select(m => new FeedPostMediaDto()
                    {
                        MediaId = m.MediaId,
                        Data = m.Data,
                        FileExtension = m.FileExtension,
                        Filename = m.Filename
                    })
                    .ToList()
                : null,
            Hashtags = p.Hashtags != null
                ? p.Hashtags.Select(h => new FeedPostHashtagDto()
                {
                    HashtagId = h.HashtagId,
                    Name = h.Name
                })
                .ToList()
                : null,
            PostEventId = p.PostEventId,
            Event = p.Event != null
                ? new ResponseEventDto()
                {
                    EventId = p.Event.EventId,
                    Name = p.Event.Name,
                    Slug = p.Event.Slug
                }
                : null,
            PostWineId = p.PostWineId,
            Wine = p.Wine != null
                ? new FeedPostWineDto()
                {
                    WineId = p.Wine.WineId,
                    BrandId = p.Wine.BrandId,
                    Brand = new ResponseBrandDto()
                    {
                        BrandId = p.Wine.BrandId,
                        Name = p.Wine.Brand.Name,
                        Description = p.Wine.Brand.Description
                    },
                    RegionId = p.Wine.RegionId,
                    Region = new ResponseRegionDto()
                    {
                        RegionId = p.Wine.RegionId,
                        Name = p.Wine.Region.Name
                    },
                    Label = p.Wine.label,
                    LabelDesignation = p.Wine.LabelDesignation,
                    Category = p.Wine.category
                }
                : null
        };
        return post;
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
            Likes = post.Likes.Where(l => l.IsActive)
                .Select(l => new FeedPostUserDto
                {
                    UserId = l.UserId,
                    Email = l.User.Email
                })
                .ToList(),
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
                })
                .ToList(),
            PostWineId = post.PostWineId,
            PostEventId = post.PostEventId
        };

        if (postDto.PostWineId is not null)
        {
            var wine = _context.Wines.Find(postDto.PostWineId);
            postDto.Wine = new FeedPostWineDto()
            {
                BrandId = wine.BrandId,
                Label = wine.label,
                Category = wine.category,
                Year = wine.Year,
                LabelDesignation = wine.LabelDesignation
            };
            var brand = _context.Brands.Find(postDto.Wine.BrandId);
            postDto.Wine.Brand = new ResponseBrandDto()
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description
            };
        }

        if (postDto.PostEventId is not null)
        {
            var evento = _context.Events.Find(postDto.PostEventId);
            postDto.Event = new ResponseEventDto()
            {
                EventId = evento.EventId,
                Name = evento.Name,
                Slug = evento.Slug
            };
        }

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
                foreach (var m in createFeedPostDto.Media)
                {
                    var media = new PostMedia()
                    {
                        Data = m.Data,
                        FileExtension = m.FileExtension,
                        Filename = m.Filename,
                        MediaPostId = post.PostId
                    };
                    _context.PostMedia.Add(media);
                }

            var hashtags = new List<Hashtag>();
            if (createFeedPostDto.Hashtags is not null)
            {
                foreach (var postHashtag in createFeedPostDto.Hashtags)
                {
                    if (postHashtag.Name != null)
                    {
                        postHashtag.Name = postHashtag.Name.ToLowerInvariant();
                        var hashtag = _context.Hashtags
                            .FirstOrDefault(h => h.Name == postHashtag.Name);

                        if (hashtag is null)
                        {
                            hashtag = new Hashtag() { Name = postHashtag.Name };
                            _context.Hashtags.Add(hashtag);
                        }

                        hashtags.Add(hashtag);
                    }
                }
            }

            post.PostWineId = createFeedPostDto.PostWineId;
            post.PostEventId = createFeedPostDto.PostEventId;

            post.Hashtags = hashtags;

            var postEntry = _context.Posts.Add(post);
            
            await _context.SaveChangesAsync();

            return MapToFeedPostDto(postEntry.Entity);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while creating the post.",
                ex);
        }
    }

    public async Task<FeedPostDto> UpdatePost(Guid id,
        FeedPostDto updatePostDto)
    {
        var post = _context.Posts.Find(id);

        if (post == null)
            throw new ArgumentException("Post not found.");

        post.Text = updatePostDto.Text ?? post.Text;

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

                if (post == null)
                    throw new ArgumentException("Post not found.");

                var postMedia =_context.PostMedia.Where(m => m.MediaPostId == id);
                _context.PostMedia.RemoveRange(postMedia);
                
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