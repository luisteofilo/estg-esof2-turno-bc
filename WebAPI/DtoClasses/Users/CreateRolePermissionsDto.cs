namespace ESOF.WebApp.WebAPI.Controller.Dto.Users;

public class CreateRolePermissionsDto
{
    public Guid RoleId { get; set; }
    
    public Guid PermissionId { get; set; }
}