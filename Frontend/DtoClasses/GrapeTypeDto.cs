using ESOF.WebApp.DBLayer.Entities;

namespace Frontend.DtoClasses
{
    public class GrapeTypeDto
    {
        public Guid GrapeTypeId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DeletedAt { get; set; }
    }
}