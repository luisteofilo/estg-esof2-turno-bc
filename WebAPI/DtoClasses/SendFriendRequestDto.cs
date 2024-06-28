namespace ESOF.WebApp.WebAPI.DtoClasses;

public class SendFriendRequestDto
{
    public Guid RequesterId { get; set; }
    public Guid ReceiverId { get; set; }
}