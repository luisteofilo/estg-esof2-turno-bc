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
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
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
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt
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
                PasswordHash = createUserDto.PasswordHash,
                PasswordSalt = createUserDto.PasswordSalt
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
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
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
        user.PasswordHash = updateUserDto.PasswordHash;
        user.PasswordSalt = updateUserDto.PasswordSalt;

        context.SaveChanges();

        return new ResponseUserDto
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            BirthdayDate = user.BirthdayDate,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt
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
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while trying to delete user!", e);
            }
        }
    }
}