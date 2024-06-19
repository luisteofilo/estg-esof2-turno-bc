using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class Post
{
    [Key]
    public Guid PostId { get; set; }
    
    [Required, ForeignKey("User")]
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }

    [Required]
    public DateTimeOffset DateTimePost { get; set; }
    
    public string? Text { get; set; }

    public List<PostMedia> Media { get; set; }
    public List<Hashtag> Hashtags { get; set; }

    [Required]
    public PostVisibilityType VisibilityType { get; set; }
    
    [NotMapped]
    public List<User> FavoriteUsers { get; set; }
    [NotMapped]
    public List<User> HiddenUsers { get; set; }
    [NotMapped]
    public List<User> ViewUsers { get; set; }
    [NotMapped]
    public List<Tuple<User, User>> ShareUsers { get; set; }
    
    
    
    public ICollection<Like> Likes { get; set; } 
    public ICollection<Comment> Comments { get; set; } 
    public int LikesCount { get; set; }
    public int CommentCount { get; set; }
    
}