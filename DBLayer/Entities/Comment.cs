using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class Comment
{
    [Key]
    public Guid CommentId { get; set; }
        
    [Required, ForeignKey("Post")]
    public Guid PostId { get; set; }
        
    [Required, ForeignKey("User")]
    public Guid UserId { get; set; } 
        
    [Required]
    public string Content { get; set; }
        
    [Required]
    public DateTime CreatedAt { get; set; }
        
    [Required]
    public DateTime UpdatedAt { get; set; } 

    public Post Post { get; set; } 
    public User User { get; set; } 
}