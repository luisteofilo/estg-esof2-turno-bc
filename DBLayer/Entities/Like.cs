using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class Like
{
    [Key]
    public Guid LikeId { get; set; }
        
    [Required]
    public Guid PostId { get; set; }
    [ForeignKey("PostId")]
    public Post Post { get; set; }
        
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
        
    [Required]
    public DateTime CreatedAt { get; set; }
        
    [Required]
    public bool IsActive { get; set; }

}