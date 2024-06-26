namespace ESOF.WebApp.WebAPI.DtoClasses;

public class RemoveFriendDto
{
    public Guid UserId { get; set; }
    public Guid FriendId { get; set; }
}