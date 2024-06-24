namespace Frontend.DtoClasses
{
    public class EventParticipantDto
    {
        public Guid EventParticipantId { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
