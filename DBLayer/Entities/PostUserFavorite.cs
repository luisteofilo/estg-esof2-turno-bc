using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(FavoritePostId), nameof(FavoriteUserId))]
public class PostUserFavorite
{
    public Guid FavoritePostId { get; set; }
    [ForeignKey(nameof(FavoritePostId))]
    public Post Post { get; set; }
    
    public Guid FavoriteUserId { get; set; }
    [ForeignKey(nameof(FavoriteUserId))]
    public User User { get; set; }
}