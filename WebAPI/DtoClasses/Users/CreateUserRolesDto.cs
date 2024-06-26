namespace ESOF.WebApp.WebAPI.Controller.Dto.Users;

public class CreateUserRolesDto
{
    public Guid UserId { get; set; }
    
    public Guid RoleId { get; set; }
}