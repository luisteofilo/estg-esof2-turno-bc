using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(FollowerUserId), nameof(UserFollowedId))]
public class Follow
{
    [ForeignKey("User")]
    public Guid FollowerUserId { get; set; }
    public User FollowerUser { get; set; }
    
    [ForeignKey("User")]
    public Guid UserFollowedId { get; set; }
    public User UserFollowed { get; set; }
}