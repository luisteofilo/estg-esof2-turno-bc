using Helpers.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Frontend.Components.Pages;

public partial class Post
{
    [Parameter] public FeedPost PostLine { get; set; }
    
}