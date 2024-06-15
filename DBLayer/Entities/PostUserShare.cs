using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(SharedPostId), nameof(UserSentId), nameof(UserReceivedId))]
public class PostUserShare
{
    public Guid SharedPostId { get; set; }
    [ForeignKey(nameof(SharedPostId))]
    public Post Post { get; set; }
    
    public Guid UserSentId { get; set; }
    [ForeignKey(nameof(UserSentId))]
    public User UserSent { get; set; }
    
    public Guid UserReceivedId { get; set; }
    [ForeignKey(nameof(UserReceivedId))]
    public User UserReceived { get; set; }
}