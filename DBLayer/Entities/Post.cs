using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class Post
{
    [Key]
    public Guid PostId { get; set; }
    
    public Guid CreatorId { get; set; }
    [Required, ForeignKey(nameof(CreatorId))]
    public User Creator { get; set; }

    [Required]
    public DateTime DateTimePost { get; set; }
    
    public string Text { get; set; }

    public List<PostMedia> Media { get; set; }
    public List<Hashtag> Hashtags { get; set; }

    public PostVisibilityType VisibilityType { get; set; }
    
    public List<User> FavoriteUsers { get; set; }
    public List<User> HiddenUsers { get; set; }
    public List<User> ViewUsers { get; set; }

    public List<Tuple<User, User>> ShareUsers { get; set; }
}