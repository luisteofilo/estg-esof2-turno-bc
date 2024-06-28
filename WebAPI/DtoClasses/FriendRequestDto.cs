using ESOF.WebApp.DBLayer.Entities;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class FriendRequestDto
{
    public Guid RequestId { get; set; }
    public Guid RequesterId { get; set; }
    public string RequesterName { get; set; }
    public Guid ReceiverId { get; set; }
    public string ReceiverName { get; set; } 
    public FriendRequestState Status { get; set; }
    public DateTime CreatedAt { get; set; }
}