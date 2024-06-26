using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ResponseUserDto> GetAllUsers()
    {
        try
        {
            return _context.Users.Select(user => new ResponseUserDto
            {
                UserId = user.UserId,
                Email = user.Email
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving users.", ex);
        }
    }
}