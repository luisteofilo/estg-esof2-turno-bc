using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Post
{
    [Key]
    public Guid PostId { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [Required]
    public DateTime DateTimePost { get; set; }
    
    public string Text { get; set; }

    public List<PostMedia> Media { get; set; }
    public List<Hashtag> Hashtags { get; set; }
    
    public PostVisibilityType VisibilityType { get; set; }
    
    public Guid RepostId { get; set; }
}