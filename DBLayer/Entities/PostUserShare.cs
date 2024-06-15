using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(SharedPostId), nameof(UserSentId), nameof(UserReceivedId))]
public class PostUserShare
{
    [ForeignKey("Post")]
    public Guid SharedPostId { get; set; }
    public Post SharedPost { get; set; }
    
    [ForeignKey("User")]
    public Guid UserSentId { get; set; }
    public User UserSent { get; set; }
    
    [ForeignKey("User")]
    public Guid UserReceivedId { get; set; }
    public User UserReceived { get; set; }
}