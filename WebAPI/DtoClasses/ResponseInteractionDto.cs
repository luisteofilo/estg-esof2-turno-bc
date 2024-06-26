namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseInteractionDto
{
    public Guid InteractionLinkId { get; set; }
    public Guid UserId { get; set; }
    public Guid WineId { get; set; }
    public int InteractionType { get; set; }
}