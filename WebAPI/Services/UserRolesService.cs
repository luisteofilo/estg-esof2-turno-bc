using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class UserRolesService (ApplicationDbContext context)
{
    public List<ResponseUserRolesDto> GetAllUserRoles()
    {
        try
        {
            return context.UserRoles.Select(role =>  new ResponseUserRolesDto()
            {
                RoleId = role.RoleId,
                UserId = role.UserId
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while retrieving User Roles. ", e);
        }
    }

    public ResponseUserRolesDto getUserRolesById(Guid id)
    {
        var userRoles = context.UserRoles.Find(id);
        if (userRoles == null)
        {
            throw new ArgumentException("Error: User Role not found!");
        }

        return new ResponseUserRolesDto()
        {
            RoleId = userRoles.RoleId,
            UserId = userRoles.UserId
        };
    }

    public ResponseUserRolesDto CreateUserRole(CreateUserRolesDto createUserRolesDto)
    {
        try
        {
            var userRole = new UserRole
            {
                RoleId = createUserRolesDto.RoleId,
                UserId = createUserRolesDto.UserId
            };

            context.UserRoles.Add(userRole);
            context.SaveChanges();

            return new ResponseUserRolesDto()
            {
                RoleId = userRole.RoleId,
                UserId = userRole.UserId
            };
        }
        catch (DbUpdateException e)
        {
            throw new Exception("An error occurred while creating user role", e);
        }
    }

    public ResponseUserRolesDto UpdateUserRoles(Guid id, UpdateUserRolesDto updateUserRoleDto)
    {
        var userRoles = context.UserRoles.Find(id);

        if (userRoles == null)
        {
            throw new Exception("Error: User Role not found!");
        }

        userRoles.RoleId = updateUserRoleDto.RoleId;
        userRoles.UserId = updateUserRoleDto.UserId;

        context.SaveChanges();

        return new ResponseUserRolesDto()
        {
            RoleId = userRoles.RoleId,
            UserId = userRoles.UserId
        };
    }

    public void DeleteUserRoles(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var userRoles = context.UserRoles.Find(id);
    
                if (userRoles == null)
                {
                    throw new Exception("Error: User Role not found!");
                }

                context.UserRoles.Remove(userRoles);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while trying to delete User Role!", e);
            }
        }
    }
}
