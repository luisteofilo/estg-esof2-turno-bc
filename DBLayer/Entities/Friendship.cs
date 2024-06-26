using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESOF.WebApp.DBLayer.Entities
{
    public class Friendship
    {
        [Key]
        public Guid FriendshipId { get; set; }

        [Required, ForeignKey("User1")]
        public Guid UserId1 { get; set; }
        public User User1 { get; set; }

        [Required, ForeignKey("User2")]
        public Guid UserId2 { get; set; }
        public User User2 { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
