using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class RolePermissionsService (ApplicationDbContext context)
{
    public List<ResponseRolePermissionsDto> GetAllRolePermissions()
    {
        try
        {
            return context.RolePermissions.Select(RolePermission => new ResponseRolePermissionsDto
            {
                RoleId = RolePermission.RoleId,
                PermissionId = RolePermission.PermissionId
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while retrieving RolePermission. ", e);
        }
    }

    public ResponseRolePermissionsDto getRolePermissionById(Guid roleId, Guid permissionId)
    {
        var rolePermission = context.RolePermissions.Find(roleId, permissionId);
        if (rolePermission == null)
        {
            throw new ArgumentException("Error: RolePermission not found!");
        }

        return new ResponseRolePermissionsDto()
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        };
    }

    public ResponseRolePermissionsDto CreateRolePermission(CreateRolePermissionsDto createRolePermissionsDto)
    {
        try
        {
            var rolePermission = new RolePermission
            {
                RoleId = createRolePermissionsDto.RoleId,
                PermissionId = createRolePermissionsDto.PermissionId
            };

            context.RolePermissions.Add(rolePermission);
            context.SaveChanges();

            return new ResponseRolePermissionsDto()
            {
                RoleId = rolePermission.RoleId,
                PermissionId = rolePermission.PermissionId
            };
        }
        catch (DbUpdateException e)
        {
            throw new Exception("An error occurred while creating role permission", e);
        }
    }

    public ResponseRolePermissionsDto UpdateRolePermission(Guid roleId, Guid permissionId, UpdateRolePermissionsDto updateRolePermissionDto)
    {
        var rolePermission = context.RolePermissions.Find(roleId, permissionId);

        if (rolePermission == null)
        {
            throw new Exception("Error: Role Permission not found!");
        }

        rolePermission.RoleId = updateRolePermissionDto.RoleId;
        rolePermission.PermissionId = updateRolePermissionDto.PermissionId;

        context.SaveChanges();

        return new ResponseRolePermissionsDto()
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        };
    }

    public void DeleteRolePermission(Guid roleId, Guid permissionId)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var rolePermission = context.RolePermissions.Find(roleId, permissionId);
    
                if (rolePermission == null)
                {
                    throw new Exception("Error: Role Permission not found!");
                }

                context.RolePermissions.Remove(rolePermission);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while trying to delete Role Permission!", e);
            }
        }
    }
}