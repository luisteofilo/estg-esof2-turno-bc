﻿using Helpers.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Frontend.Components.Pages;

public partial class Post
{
    [Parameter] public FeedPost feedpost { get; set; }
    
}