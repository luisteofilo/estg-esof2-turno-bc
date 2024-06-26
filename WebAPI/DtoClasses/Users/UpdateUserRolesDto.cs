namespace ESOF.WebApp.WebAPI.Controller.Dto.Users;

public class UpdateUserRolesDto
{
    public Guid UserId { get; set; }
    
    public Guid RoleId { get; set; }
}