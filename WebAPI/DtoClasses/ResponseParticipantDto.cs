namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseParticipantDto
{
    public Guid ParticipantId { get; set; }
    public Guid UserId { get; set; }
    public Guid BlindEventId { get; set; }
    
    // estes campos são para mostrar os dados relacionados em completa informação
    public ResponseUserDto User { get; set; }
    public ResponseBlindEventDto BlindEvent { get; set; }
    
}