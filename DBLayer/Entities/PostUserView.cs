using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.DBLayer.Entities;

[PrimaryKey(nameof(ViewedPostId), nameof(ViewedUserId))]
public class PostUserView
{
    [ForeignKey("Post")]
    public Guid ViewedPostId { get; set; }
    public Post PostV { get; set; }
    
    [ForeignKey("User")]
    public Guid ViewedUserId { get; set; }
    public User UserV { get; set; }
}