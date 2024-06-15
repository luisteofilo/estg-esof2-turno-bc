using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Hashtag
{
    [Key]
    public Guid HashtagId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int NumPosts { get; set; }
    public List<Post> Posts { get; set; }
}