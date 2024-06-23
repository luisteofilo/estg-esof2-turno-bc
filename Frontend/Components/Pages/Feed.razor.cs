using Frontend.Helpers;
using Helpers.ViewModels;

namespace Frontend.Components.Pages;

public partial class Feed
{
    private FeedPost _newPost;
    private FeedPostList _feedPosts;
    protected override async Task OnInitializedAsync()
    {
        _feedPosts = await ApiHelper.GetFromApiAsync<FeedPostList>("api/post/index");
    }
    
    private void CreatePost()
    {
        
    }
}