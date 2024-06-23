using System.ComponentModel.DataAnnotations;

namespace Helpers.ViewModels;

public class FeedPost
{
    public Guid PostId { get; set; }
    public string Text { get; set; }
    
    public Guid CreatorId { get; set; }
    public FeedPostUser Creator { get; set; }
    
    public DateTimeOffset DateTimePost { get; set; }
    
    public IEnumerable<FeedPostMedia> Media { get; set; }
}

public class FeedPostMedia
{
    
}

public class FeedPostUser
{
    public string email;
}

public class FeedPostList
{
    public IEnumerable<FeedPost> Lines { get; set; }
}
