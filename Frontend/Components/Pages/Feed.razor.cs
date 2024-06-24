using Frontend.Helpers;
using Helpers.ViewModels;

namespace Frontend.Components.Pages;

public partial class Feed
{
    private FeedPost _newPost = new FeedPost();
    private FeedPostList _feedPosts = new FeedPostList();
    protected override async Task OnInitializedAsync()
    {
        _feedPosts.Posts = await ApiHelper.GetFromApiAsync<List<FeedPost>>("api/Post/index");
    }
    
    private async Task CreatePost()
    {
        await ApiHelper.PostToApiAsync<FeedPost>("api/Post/create", _newPost);
    }
}