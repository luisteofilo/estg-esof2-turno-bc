namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateEvaluationDto
{
    public Guid ParticipantId { get; set; }
    public Guid WineId { get; set; }
    public Guid BlindEventId { get; set; }
    public int Grade { get; set; }
}