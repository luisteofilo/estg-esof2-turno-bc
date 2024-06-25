using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class CreateBlindEventDto
{
    [Required]
    public Guid OrganizerId { get; set; }
    [Required]
    public DateTime EventDate { get; set; }
    [Required, StringLength(100, MinimumLength = 1)]
    public string Name { get; set; }
    public ICollection<Guid> ParticipantIds { get; set; } = new List<Guid>();
    public ICollection<Guid> EvaluationIds { get; set; } = new List<Guid>();
    public ICollection<Guid> ParticipantWineIds { get; set; } = new List<Guid>();
}