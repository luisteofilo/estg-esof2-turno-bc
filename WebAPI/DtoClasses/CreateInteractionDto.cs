namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateInteractionDto
{
    public Guid UserId { get; set; }
    public Guid WineId { get; set; }
    public int InteractionType { get; set; }
}