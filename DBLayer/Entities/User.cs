using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }

    [EmailAddress, Required]
    public string Email { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }
        
    [Required]
    public string UserName { get; set; }

    public int FriendsCount { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<FriendRequest> SentFriendshipRequests { get; set; }
    public ICollection<FriendRequest> ReceivedFriendshipRequests { get; set; }
    public ICollection<Post> Posts { get; set; }

    // Collection of friendships where this user is User1 (User that sent the friend request)
    public ICollection<Friendship> Friendships1 { get; set; }

    // Collection of friendships where this user is User2 (User that receives the friend request)
    public ICollection<Friendship> Friendships2 { get; set; }


    public ICollection<EventParticipant> EventParticipants { get; set; }
    public ICollection<Interaction> Interactions { get; set; }
    
    public ICollection<BlindEvent> OrganizedEvents { get; set; }

    
    public ICollection<Participant> Participants { get; set; }

    public User()
    {
        OrganizedEvents = new List<BlindEvent>();
        Participants = new List<Participant>();
    }
}