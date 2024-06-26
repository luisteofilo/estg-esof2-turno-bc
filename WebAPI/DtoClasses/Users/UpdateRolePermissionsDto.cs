namespace ESOF.WebApp.WebAPI.Controller.Dto.Users;

public class UpdateRolePermissionsDto
{
    public Guid RoleId { get; set; }
    
    public Guid PermissionId { get; set; }
}
