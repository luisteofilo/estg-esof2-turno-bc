using System.Data;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class PermissonService(ApplicationDbContext context)
{
    public List<ResponsePermissionsDto> getAllPermissions()
    {
        try
        {
            return context.Permissions.Select(permission => new ResponsePermissionsDto
            {
                Name = permission.Name,
                PermissionId = permission.PermissionId
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("Error: An error occurred while retrieving permissions.", e);
        }
    }

    public ResponsePermissionsDto GetPermissionById(Guid id)
    {
        var permission = context.Permissions.Find(id);

        if (permission == null)
        {
            throw new ArgumentException("Error: permission not found!");
        }

        return new ResponsePermissionsDto
        {
            PermissionId = permission.PermissionId,
            Name = permission.Name
        };
    }

    public ResponsePermissionsDto CreatePermission(CreatePermissionsDto createPermissionsDto)
    {
        try
        {
            var permission = new Permission
            {
                Name = createPermissionsDto.Name
            };

            context.Permissions.Add(permission);
            context.SaveChanges();

            return new ResponsePermissionsDto
            {
                PermissionId = permission.PermissionId,
                Name = permission.Name
            };
        }
        catch (DbUpdateException e)
        {
            throw new Exception("Error: An error occurred while creating permission!", e);
        }
    }

    public ResponsePermissionsDto UpdatePermission(Guid id, UpdatePermissionDto updatePermissionDto)
    {
        var permission = context.Permissions.Find(id);

        if (permission == null)
        {
            throw new ArgumentException("Error: permission not found!");
        }

        permission.Name = updatePermissionDto.Name;

        context.SaveChanges();

        return new ResponsePermissionsDto
        {
            PermissionId = permission.PermissionId,
            Name = permission.Name
        };
    }

    public void DeletePermission(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var permission = context.Permissions.Find(id);
                
                if (permission == null)
                {
                    throw new Exception("Error: permission not found!");
                }

                context.Permissions.Remove(permission);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Error: An error occurred while trying to delete permisson!", e);
            }
        }
    }
}