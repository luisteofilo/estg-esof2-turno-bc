﻿namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedHashtagDto
{
    public Guid? HashtagId { get; set; }

    public string? Name { get; set; }

    public int? NumPosts { get; set; } = 0;
    public List<FeedPostDto>? Posts { get; set; }
}