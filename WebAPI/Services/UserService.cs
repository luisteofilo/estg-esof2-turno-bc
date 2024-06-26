using System;
using System.Threading.Tasks;
using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfileDto> GetUserProfileAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.FavoriteWine)
                    .ThenInclude(w => w.Brand)
                .Include(u => u.FavoriteWine)
                    .ThenInclude(w => w.Region)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new UserProfileDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                WineId = user.FavoriteWine?.WineId ?? Guid.Empty,
                FavoriteWine = user.FavoriteWine == null ? null : new WineDto
                {
                    WineId = user.FavoriteWine.WineId,
                    Name = user.FavoriteWine.Name,
                    Brand = user.FavoriteWine.Brand == null ? null : new BrandDto
                    {
                        BrandId = user.FavoriteWine.Brand.BrandId,
                        Name = user.FavoriteWine.Brand.Name
                    },
                    Region = user.FavoriteWine.Region == null ? null : new RegionDto
                    {
                        RegionId = user.FavoriteWine.Region.RegionId,
                        Name = user.FavoriteWine.Region.Name
                    }
                }
            };
        }

        public async Task EditUserProfileAsync(EditUserProfileDto userProfileDto)
        {
            var user = await _context.Users.FindAsync(userProfileDto.UserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Username = userProfileDto.Username;
            user.Email = userProfileDto.Email;

            if (userProfileDto.FavoriteWine != null)
            {
                user.FavoriteWineId = userProfileDto.FavoriteWine.WineId;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
