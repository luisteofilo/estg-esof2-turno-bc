using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController()
    {
        _userService = new UserService(new ApplicationDbContext());
    }

    [HttpGet("index")]
    public ActionResult<List<ResponseUserDto>> GetAllUsers()
    {
        try
        {
            return _userService.GetAllUsers();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }
}