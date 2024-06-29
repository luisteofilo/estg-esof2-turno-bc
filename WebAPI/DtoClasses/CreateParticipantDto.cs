namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateParticipantDto
{
    public Guid UserId { get; set; }
    public Guid BlindEventId { get; set; }
    public ICollection<Guid> EvaluationIds { get; set; }
    public ICollection<Guid> ParticipantWineIds { get; set; } 
}