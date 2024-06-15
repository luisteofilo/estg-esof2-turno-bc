using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(HiddenPostId), nameof(HiddenUserId))]
public class PostUserHidden
{
    public Guid HiddenPostId { get; set; }
    [ForeignKey(nameof(HiddenPostId))]
    public Post Post { get; set; }
    
    public Guid HiddenUserId { get; set; }
    [ForeignKey(nameof(HiddenUserId))]
    public User User { get; set; }
}