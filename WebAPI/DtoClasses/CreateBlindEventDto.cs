namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateBlindEventDto
{
    public Guid OrganizerId { get; set; }
    public DateTime EventDate { get; set; }
    public string Name { get; set; }
    public ICollection<Guid> ParticipantIds { get; set; }
    public ICollection<Guid> EvaluationIds { get; set; }
    public ICollection<Guid> ParticipantWineIds { get; set; }
}