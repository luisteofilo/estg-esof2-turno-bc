using System.Runtime.InteropServices.JavaScript;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;

namespace ESOF.WebApp.WebAPI.Services;

public class UserService(ApplicationDbContext context) 
{
    public List<ResponseUserDto> GetAllUsers()
    {
        try
        {
            return context.Users.Select(user => new ResponseUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                BirthdayDate = user.BirthdayDate,
                Email = user.Email
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while retrieving users. ", e);
        }
    }

    public ResponseUserDto getUserById(Guid id)
    {
        var user = context.Users.Find(id);
        if (user == null)
        {
            throw new ArgumentException("Error: user not found!");
        }

        return new ResponseUserDto()
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            BirthdayDate = user.BirthdayDate,
            Email = user.Email
        };
    }

    public ResponseUserDto CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            var user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Address = createUserDto.Address,
                BirthdayDate = createUserDto.BirthdayDate,
                Email = createUserDto.Email
                //TODO
                //passwordHash and passwordhSalt
            };
        }
        catch (Exception e)
        {
            
        }
    }
}