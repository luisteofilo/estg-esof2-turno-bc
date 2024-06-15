using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(FollowerUserId), nameof(UserFollowedId))]
public class Follow
{
    public Guid FollowerUserId { get; set; }
    [ForeignKey(nameof(FollowerUserId))]
    public User FollowerUser { get; set; }
    
    public Guid UserFollowedId { get; set; }
    [ForeignKey(nameof(UserFollowedId))]
    public User UserFollowed { get; set; }
}