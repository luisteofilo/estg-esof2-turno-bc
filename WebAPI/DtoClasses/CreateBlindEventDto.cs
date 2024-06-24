namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateBlindEventDto
{
    public Guid OrganizerId { get; set; }
    public DateTime EventDate { get; set; }
    public string Name { get; set; }
    public ICollection<Guid> ParticipantIds { get; set; } = new List<Guid>();
    public ICollection<Guid> EvaluationIds { get; set; } = new List<Guid>();
    public ICollection<Guid> ParticipantWineIds { get; set; } = new List<Guid>();
}