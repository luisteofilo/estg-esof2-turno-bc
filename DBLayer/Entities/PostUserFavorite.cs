using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(FavoritePostId), nameof(FavoriteUserId))]
public class PostUserFavorite
{
    [ForeignKey(nameof(Entities.Post))]
    public Guid FavoritePostId { get; set; }
    public Post Post { get; set; }
    
    [ForeignKey(nameof(Entities.User))]
    public Guid FavoriteUserId { get; set; }
    public User User { get; set; }
}