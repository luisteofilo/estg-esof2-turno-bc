using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(HiddenPostId), nameof(HiddenUserId))]
public class PostUserHidden
{
    [ForeignKey("Post")]
    public Guid HiddenPostId { get; set; }
    public Post PostH { get; set; }
    
    [ForeignKey("User")]
    public Guid HiddenUserId { get; set; }
    public User UserH { get; set; }
}