namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseParticipantWineDto
{
    public Guid ParticipantWineId { get; set; }
    public Guid ParticipantId { get; set; }
    public Guid WineId { get; set; }
    public Guid BlindEventId { get; set; }
    
    // estes campos são para mostrar os dados relacionados em completa informação
    
    public ResponseParticipantDto Participant { get; set; }
    public ResponseWineDto Wine { get; set; }
    public ResponseBlindEventDto BlindEvent { get; set; }
}