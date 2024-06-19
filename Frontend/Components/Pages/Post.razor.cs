using Microsoft.AspNetCore.Components;

namespace Frontend.Components.Pages;

public partial class Post
{
    [Parameter] public string text { get; set; }
    
}