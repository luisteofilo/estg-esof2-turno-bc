namespace ESOF.WebApp.WebAPI.DtoClasses;

public class ResponseGrapeTypeDto
{
    public Guid GrapeTypeId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}