using System.Data;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class RoleService(ApplicationDbContext context)
{
    public List<ResponseRolesDto> GetAllRoles()
    {
        try
        {
            return context.Roles.Select(role => new ResponseRolesDto
            {
                RoleId = role.RoleId,
                Name = role.Name
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("Error: An error occurred while retrieving roles!", e);
        }
    }

    public ResponseRolesDto GetRoleById(Guid id)
    {
        var role = context.Roles.Find(id);

        if (role == null)
        {
            throw new ArgumentException("Error: role not found!");
        }

        return new ResponseRolesDto
        {
            RoleId = role.RoleId,
            Name = role.Name
        };
    }

    public ResponseRolesDto CreateRole(CreateRolesDto createRolesDto)
    {
        try
        {
            var role = new Role
            {
                Name = createRolesDto.Name
            };

            context.Roles.Add(role);
            context.SaveChanges();

            return new ResponseRolesDto
            {
                RoleId = role.RoleId,
                Name = role.Name
            };
        }
        catch (DbUpdateException e)
        {
            throw new Exception("Error: An error occurred while trying to create role", e);
        }
    }

    public ResponseRolesDto UpdateRole(Guid id, UpdateRolesDto updateRolesDto)
    {
        var role = context.Roles.Find(id);

        if (role == null)
        {
            throw new Exception("Error: role not found!");
        }

        role.Name = updateRolesDto.Name;

        return new ResponseRolesDto
        {
            RoleId = role.RoleId,
            Name = role.Name
        };
    }

    public void DeleteRole(Guid id)
    {
        using (var transaction =  context.Database.BeginTransaction())
        {
            try
            {
                var role = context.Roles.Find(id);

                if (role == null)
                {
                    throw new Exception("Error: role not found!");
                }

                context.Roles.Remove(role);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Error: An error occurred while trying to delete role!", e);
            }
        }
    }
}