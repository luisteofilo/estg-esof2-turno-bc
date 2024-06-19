using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESOF.WebApp.DBLayer.Entities;
public class Friend
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid FriendId { get; set; }

    [Required]
    public DateTime FriendsSince { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    [ForeignKey(nameof(FriendId))]
    public User FriendUser { get; set; }
}