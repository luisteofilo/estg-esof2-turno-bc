using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Hashtag
{
    [Key]
    public Guid HashtagId { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required] 
    public int NumPosts { get; set; } = 0;
    public List<Post> Posts { get; set; }
}