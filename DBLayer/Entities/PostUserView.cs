using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(ViewedPostId), nameof(ViewedUserId))]
public class PostUserView
{
    public Guid ViewedPostId { get; set; }
    [ForeignKey(nameof(ViewedPostId))]
    public Post Post { get; set; }
    
    public Guid ViewedUserId { get; set; }
    [ForeignKey(nameof(ViewedUserId))]
    public User User { get; set; }
}