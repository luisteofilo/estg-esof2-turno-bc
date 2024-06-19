namespace Helpers.ViewModels;

public class PostsListLine
{
    public string Title { get; set; }
    public string Author { get; set; }
}

public class PostsList
{
    public IEnumerable<PostsListLine> Lines { get; set; }
}