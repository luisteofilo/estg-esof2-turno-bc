using Frontend.Helpers;
using Helpers.ViewModels;

namespace Frontend.Components.Pages;

public partial class Feed
{
    private PostsListLine _newPost;
    private PostsList _feedPosts;
    protected override async Task OnInitializedAsync()
    {
        _feedPosts = await ApiHelper.GetFromApiAsync<PostsList>("/deleteaccess/allposts");
    }

    
}