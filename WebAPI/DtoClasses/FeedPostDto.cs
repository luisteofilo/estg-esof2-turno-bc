﻿using ESOF.WebApp.DBLayer.Entities;
using WebAPI.DtoClasses;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FeedPostDto
{
    public Guid PostId { get; set; } 
    public string? Text { get; set; }
    
    public Guid? CreatorId { get; set; }
    public FeedPostUserDto? Creator { get; set; }
    
    public DateTimeOffset? DateTimePost { get; set; }
    
    public IEnumerable<FeedPostMediaDto>? Media { get; set; }
    
    public IEnumerable<FeedPostHashtagDto>? Hashtags { get; set; }
    
    public PostVisibilityType? VisibilityType { get; set; }
    
    // public IEnumerable<FeedPostUserDto>? FavoriteUsers { get; set; }
    //
    // public IEnumerable<FeedPostUserDto>? HiddenUsers { get; set; }
    //
    // public IEnumerable<FeedPostUserDto>? ViewUsers { get; set; }
    //
    // public IEnumerable<Tuple<FeedPostUserDto, FeedPostUserDto>>? ShareUsers { get; set; }
    
    public Guid? EventId { get; set; }
    public ResponseEventDto? Event { get; set; }
    
    public Guid? WineId { get; set; }
    public ResponseWineDto? Wine { get; set; }
}