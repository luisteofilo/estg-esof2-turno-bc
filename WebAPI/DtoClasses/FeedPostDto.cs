using ESOF.WebApp.DBLayer.Entities;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostDto
{
    public Guid? PostId { get; set; } 
    public string? Text { get; set; }
    
    public Guid? CreatorId { get; set; }
    public FeedPostUserDto? Creator { get; set; }
    
    public DateTimeOffset? DateTimePost { get; set; }
    
    public IEnumerable<FeedPostMediaDto>? Media { get; set; }
    
    public IEnumerable<FeedPostHashtagDto>? Hashtags { get; set; }
    
    public PostVisibilityType? VisibilityType { get; set; }
    
    public IEnumerable<FeedPostUserDto>? FavoriteUsers { get; set; }
    
    public IEnumerable<FeedPostUserDto>? HiddenUsers { get; set; }
    
    public IEnumerable<FeedPostUserDto>? ViewUsers { get; set; }
    
    public IEnumerable<Tuple<FeedPostUserDto, FeedPostUserDto>>? ShareUsers { get; set; }
    
    public int LikeCount { get; set; } 
    public bool IsLiked { get; set; } 
    public IEnumerable<FeedPostUserDto>? Likes { get; set; } 
        
    public int CommentCount { get; set; } 
    public IEnumerable<FeedPostCommentDto>? Comments { get; set; }
}