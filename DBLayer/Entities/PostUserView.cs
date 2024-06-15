using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(ViewedPostId), nameof(ViewedUserId))]
public class PostUserView
{
    [ForeignKey(nameof(Entities.Post))]
    public Guid ViewedPostId { get; set; }
    public Post Post { get; set; }
    
    [ForeignKey(nameof(Entities.User))]
    public Guid ViewedUserId { get; set; }
    public User User { get; set; }
}