using ESOF.WebApp.WebAPI.DtoClasses;
using Helpers.ViewModels;
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
                .ThenInclude(u => u.Friendships1)
                .Include(p => p.Creator)
                .ThenInclude(u => u.Friendships2)
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
                    VisibilityType = (FeedPostVisibilityType)p.VisibilityType,
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
                            Brand = new FeedPostWineBrandDto()
                            {
                                BrandId = p.Wine.BrandId,
                                Name = p.Wine.Brand.Name,
                                Description = p.Wine.Brand.Description
                            },
                            RegionId = p.Wine.RegionId,
                            Region = new FeedPostWineRegionDto()
                            {
                                RegionId = p.Wine.RegionId,
                                Name = p.Wine.Region.Name
                            },
                            Label = p.Wine.label,
                            LabelDesignation = p.Wine.LabelDesignation,
                            Category = p.Wine.category
                        }
                        : null
                })
                .OrderByDescending(p => p.DateTimePost)
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

    public bool CheckIfUserIsFollowing(Guid userCreator, Guid? userViewer)
    {
        return _context.Friendships
            .Any(f => (f.UserId1 == userCreator && f.UserId2 == userViewer)
                      || 
                      (f.UserId1 == userViewer && f.UserId2 == userCreator));
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
            VisibilityType = (FeedPostVisibilityType)p.VisibilityType,
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
                    Brand = new FeedPostWineBrandDto()
                    {
                        BrandId = p.Wine.BrandId,
                        Name = p.Wine.Brand.Name,
                        Description = p.Wine.Brand.Description
                    },
                    RegionId = p.Wine.RegionId,
                    Region = new FeedPostWineRegionDto()
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
            VisibilityType = (FeedPostVisibilityType)post.VisibilityType,
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
            postDto.Wine.Brand = MapToWineBrandDto(brand);
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

            // if (createFeedPostDto.Media is not null)
            // {
            //     foreach (var m in createFeedPostDto.Media)
            //     {
            //         var media = new PostMedia()
            //         {
            //             Data = m.Data,
            //             FileExtension = m.FileExtension,
            //             Filename = m.Filename,
            //             MediaPostId = post.PostId
            //         };
            //         _context.PostMedia.Add(media);
            //     }
            // }

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
            VisibilityType = (FeedPostVisibilityType)post.VisibilityType
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

    public async Task<ResponseEventDto> GetEventByName(string eventName)
    {
        try
        {
            var evento = await _context.Events.Where(e => e.Name == eventName).FirstOrDefaultAsync();
            if (evento is not null)
            {
                return MapToEventDto(evento);
            }
            else
            {
                throw new ArgumentException("Event not found.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while finding the event.", ex);
        }
    }

    public async Task<ResponseEventDto> GetEventBySlug(string eventSlug)
    {
        try
        {
            var evento = await _context.Events.Where(e => e.Slug == eventSlug).FirstOrDefaultAsync();
            if (evento is not null)
            {
                return MapToEventDto(evento);
            }
            else
            {
                throw new ArgumentException("Event not found.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while finding the event.", ex);
        }
    }

    public ResponseEventDto MapToEventDto(Event e)
    {
        return new ResponseEventDto()
        {
            EventId = e.EventId,
            Name = e.Name,
            Slug = e.Slug
        };
    }
    
    public async Task<FeedPostWineDto> GetWineByLabel(string wineLabel)
    {
        try
        {
            var wine = await _context.Wines
                .Include(w => w.Brand)
                .Include(w => w.Region)
                .Where(w => w.label == wineLabel).FirstOrDefaultAsync();
            if (wine is not null)
            {
                return MapToWineDto(wine);
            }
            else
            {
                throw new ArgumentException("Event not found.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while finding the event.", ex);
        }
    }

    public FeedPostWineDto MapToWineDto(Wine w)
    {
        return new FeedPostWineDto()
        {
            WineId = w.WineId,
            Label = w.label,
            LabelDesignation = w.LabelDesignation,
            BrandId = w.BrandId,
            Brand = MapToWineBrandDto(w.Brand),
            RegionId = w.RegionId,
            Region = MapToWineRegionDto(w.Region),
            Category = w.category,
            Year = w.Year
        };
    }

    public FeedPostWineBrandDto MapToWineBrandDto(Brand b)
    {
        return new FeedPostWineBrandDto()
        {
            BrandId = b.BrandId,
            Name = b.Name,
            Description = b.Description
        };
    }

    public FeedPostWineRegionDto MapToWineRegionDto(Region r)
    {
        return new FeedPostWineRegionDto()
        {
            RegionId = r.RegionId,
            Name = r.Name
        };
    }

    public async Task<FeedPostUserDto> GetUserById(Guid id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                throw new ArgumentException("User not found");
            }
            return new FeedPostUserDto()
            {
                UserId = user.UserId,
                Email = user.Email,
                UserName = user.UserName
            };
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while finding the event.", ex);
        }
    }
    
    public async Task<FeedPostUserDto> GetUserByEmail(string email)
    {
        try
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            
            if (user is null)
            {
                throw new ArgumentException("User not found");
            }
            return new FeedPostUserDto()
            {
                UserId = user.UserId,
                Email = user.Email,
                UserName = user.UserName
            };
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while finding the event.", ex);
        }
    }
}