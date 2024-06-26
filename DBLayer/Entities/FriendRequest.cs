using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities;

public class FriendRequest
{
    [Key]
    public Guid RequestId { get; set; }

    [Required]
    public Guid RequesterId { get; set; }
    [ForeignKey("RequesterId")]
    public User Requester { get; set; }

    [Required]
    public Guid ReceiverId { get; set; }
    [ForeignKey("ReceiverId")]
    public User Receiver { get; set; }

    [Required]
    public FriendRequestState Status { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}