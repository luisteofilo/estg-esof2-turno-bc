using System.Runtime.InteropServices.JavaScript;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using Microsoft.EntityFrameworkCore;
using Npgsql.TypeMapping;

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
                Email = user.Email,
                Password = user.Password
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
            Email = user.Email,
            Password = user.Password
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
                Email = createUserDto.Email,
                Password = createUserDto.Password
            };

            context.Users.Add(user);
            context.SaveChanges();

            return new ResponseUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                BirthdayDate = user.BirthdayDate,
                Email = user.Email,
                
            };
        }
        catch (DbUpdateException e)
        {
            throw new Exception("An error occurred while creating user", e);
        }
    }

    public ResponseUserDto UpdateUser(Guid id, UpdateUserDto updateUserDto)
    {
        var user = context.Users.Find(id);

        if (user == null)
        {
            throw new Exception("Error: user not found!");
        }

        user.BirthdayDate = updateUserDto.BirthdayDate;
        user.Address = updateUserDto.Address;
        user.Email = updateUserDto.Email;
        user.FirstName = updateUserDto.FirstName;
        user.LastName = updateUserDto.LastName;
        user.Password = updateUserDto.Password;

        context.SaveChanges();

        return new ResponseUserDto
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            BirthdayDate = user.BirthdayDate,
            Email = user.Email,
            Password = user.Password
        };
    }

    public void DeleteUser(Guid id)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                var user = context.Users.Find(id);
    
                if (user == null)
                {
                    throw new Exception("Error: user not found!");
                }

                context.Users.Remove(user);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while trying to delete user!", e);
            }
        }
    }
}