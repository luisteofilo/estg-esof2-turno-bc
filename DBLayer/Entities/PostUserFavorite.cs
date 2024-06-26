using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(FavoritePostId), nameof(FavoriteUserId))]
public class PostUserFavorite
{
    [ForeignKey("Post")]
    public Guid FavoritePostId { get; set; }
    public Post FavoritePost { get; set; }
    
    [ForeignKey("User")]
    public Guid FavoriteUserId { get; set; }
    public User FavoriteUser { get; set; }
}