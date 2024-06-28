namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateParticipantWineDto
{
    public Guid ParticipantId { get; set; }
    public Guid WineId { get; set; }
    public Guid BlindEventId { get; set; }
}