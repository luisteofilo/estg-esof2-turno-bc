namespace ESOF.WebApp.DBLayer.Entities;

public class TempUserPost
{
    public List<Post> CreatedPosts { get; set; }
    
    public List<Post> ViewedPosts { get; set; }
    
    public List<Post> FavoritedPosts { get; set; }
    public List<Post> HiddenPosts { get; set; }
    
    public List<Tuple<Post,User>> ReceivedPosts { get; set; }
    public List<Tuple<Post,User>> SentPosts { get; set; }
    
    public List<User> Followers { get; set; }
    public List<User> Following { get; set; }
}