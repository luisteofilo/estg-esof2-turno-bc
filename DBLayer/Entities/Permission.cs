using System.ComponentModel.DataAnnotations;

namespace ESOF.WebApp.DBLayer.Entities;

public class Permission
{
    [Key]
    public Guid PermissionId { get; set; }
    
    [Required]
    public string Name { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}