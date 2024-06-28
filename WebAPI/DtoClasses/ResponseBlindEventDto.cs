using ESOF.WebApp.DBLayer.Entities;

namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseBlindEventDto
{
    public Guid BlindEventId { get; set; }
    public DateTime EventDate { get; set; }
    public string Name { get; set; }
    public Guid OrganizerId { get; set; }
    public IEnumerable<Guid> ParticipantIds { get; set; } = new List<Guid>();
    public IEnumerable<Guid> EvalutionIds { get; set; } = new List<Guid>();
    public IEnumerable<Guid> ParticipantWineIds { get; set; } = new List<Guid>();
    
    // estes campos são para mostrar os dados relacionados em completa informação
    public ResponseUserDto Organizer { get; set; }
    public List<ResponseParticipantDto> Participants { get; set; } = new List<ResponseParticipantDto>();
    public List<ResponseEvaluationDto> Evaluations { get; set; } = new List<ResponseEvaluationDto>();
    public List<ResponseParticipantWineDto> ParticipantWines { get; set; } = new List<ResponseParticipantWineDto>();
}