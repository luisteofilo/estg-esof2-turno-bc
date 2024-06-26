using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Helpers;
using ESOF.WebApp.WebAPI.Services;

namespace ESOF.WebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            var userId = UserState.LoggedInUserId ?? Guid.Empty;
            if (userId == Guid.Empty)
            {
                return Unauthorized("User is not logged in.");
            }

            var userProfile = await _userService.GetUserProfileAsync(userId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(userProfile);
        }
    }
}