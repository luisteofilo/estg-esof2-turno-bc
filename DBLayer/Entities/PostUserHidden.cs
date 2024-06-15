using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(HiddenPostId), nameof(HiddenUserId))]
public class PostUserHidden
{
    [ForeignKey(nameof(Entities.Post))]
    public Guid HiddenPostId { get; set; }
    public Post Post { get; set; }
    
    [ForeignKey(nameof(Entities.User))]
    public Guid HiddenUserId { get; set; }
    public User User { get; set; }
}