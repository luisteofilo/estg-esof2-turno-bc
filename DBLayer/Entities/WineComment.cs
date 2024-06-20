using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class WineComment
{
    [Key]
    public Guid WineCommentId { get; set; }
    [Required]
    public string Comment  { get; set; }
    [Required]
    public int Evaluation { get; set; }
    [Required]
    public Guid WineId { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public User? User { get; set; }

    public Wine? Wine { get; set; }
    
}