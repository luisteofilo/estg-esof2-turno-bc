using System.ComponentModel.DataAnnotations;

namespace Helpers.ViewModels;

public class PostsListLine
{
    public string Text { get; set; }
    
    public Guid CreatorId { get; set; }
    public PostsUser Creator { get; set; }
    
    public IEnumerable<PostsMedia> Media { get; set; }
}

public class PostsMedia
{
    
}

public class PostsUser
{
    public string email;
}

public class PostsList
{
    public IEnumerable<PostsListLine> Lines { get; set; }
}
