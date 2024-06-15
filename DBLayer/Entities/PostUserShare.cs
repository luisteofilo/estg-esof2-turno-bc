using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(SharedPostId), nameof(UserSentId), nameof(UserReceivedId))]
public class PostUserShare
{
    [ForeignKey(nameof(Entities.Post))]
    public Guid SharedPostId { get; set; }
    public Post Post { get; set; }
    
    [ForeignKey(nameof(Entities.User))]
    public Guid UserSentId { get; set; }
    public User UserSent { get; set; }
    
    [ForeignKey(nameof(Entities.User))]
    public Guid UserReceivedId { get; set; }
    public User UserReceived { get; set; }
}