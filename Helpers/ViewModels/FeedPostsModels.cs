using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Helpers.ViewModels;

[TypeConverter(typeof(FeedPostConverter))]
public class FeedPost
{
    public Guid PostId { get; set; } 
    public string? Text { get; set; }
    
    public Guid CreatorId { get; set; }
    public FeedPostUser Creator { get; set; }
    
    public DateTimeOffset DateTimePost { get; set; }
    
    public IEnumerable<FeedPostMedia> Media { get; set; }
    
    public IEnumerable<FeedPostHashtag> Hashtags { get; set; }
    
    public FeedPostVisibilityType VisibilityType { get; set; }
    
    public IEnumerable<FeedPostUser> FavoriteUsers { get; set; }
    
    public IEnumerable<FeedPostUser> HiddenUsers { get; set; }
    
    public IEnumerable<FeedPostUser> ViewUsers { get; set; }
    
    public IEnumerable<Tuple<FeedPostUser, FeedPostUser>> ShareUsers { get; set; }
    
    public int LikeCount { get; set; }  
    public bool IsLiked { get; set; } 
    
}

public enum FeedPostVisibilityType
{
    Public,
    Followers
}
public class FeedPostHashtag
{
    public Guid HashtagId { get; set; }

    public string Name { get; set; }
    
    public int NumPosts { get; set; } = 0;
    public List<FeedPost> Posts { get; set; }
}


public class FeedPostList
{
    public List<FeedPost> Posts { get; set; } = new List<FeedPost>();
}


public class FeedPostMedia
{
    public Guid MediaId { get; set; }
    
    public Guid MediaPostId { get; set; }
    public FeedPost MediaPost { get; set; }
    
    public string Filename { get; set; }
    public string FileExtension { get; set; }
    
    public byte[] Data { get; set; }
}

public class FeedPostUser
{
    public List<FeedPost> CreatedPosts { get; set; }
    
    public List<FeedPost> ViewedPosts { get; set; }
    
    public List<FeedPost> FavoritedPosts { get; set; }
    public List<FeedPost> HiddenPosts { get; set; }
    
    public List<Tuple<FeedPost,FeedPost>> ReceivedPosts { get; set; }
    public List<Tuple<FeedPost,FeedPost>> SentPosts { get; set; }
    
    public List<FeedPost> Followers { get; set; }
    public List<FeedPost> Following { get; set; }
    
    public Guid UserId { get; set; }
    
    public string email { get; set; }
    
    public byte[] PasswordHash { get; set; }
    
    public byte[] PasswordSalt { get; set; }
    /*public ICollection<UserRole> UserRoles { get; set; }*/
}

public class FeedPostFollow
{
    public Guid FollowerUserId { get; set; }
    public FeedPostUser FollowerUser { get; set; }
    public Guid UserFollowedId { get; set; }
    public FeedPostUser UserFollowed { get; set; }
}

public class FeedPostUserView
{
    public Guid ViewedPostId { get; set; }
    public FeedPost ViewedPost { get; set; }
    public Guid ViewedUserId { get; set; }
    public FeedPostUser ViewedUser { get; set; }
}

public class FeedPostUserShare
{
    public Guid SharedPostId { get; set; }
    public FeedPost SharedPost { get; set; }
    public Guid UserSentId { get; set; }
    public FeedPostUser UserSent { get; set; }
    public Guid UserReceivedId { get; set; }
    public FeedPostUser UserReceived { get; set; }
}

public class FeedPostUserHidden
{
    public Guid HiddenPostId { get; set; }
    public FeedPost HiddenPost { get; set; }
    public Guid HiddenUserId { get; set; }
    public FeedPostUser HiddenUser { get; set; }
}

public class PostUserFavorite
{
    public Guid FavoritePostId { get; set; }
    public FeedPost FavoritePost { get; set; }
    public Guid FavoriteUserId { get; set; }
    public FeedPostUser FavoriteUser { get; set; }
}