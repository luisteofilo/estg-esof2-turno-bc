using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using ESOF.WebApp.WebAPI.DtoClasses;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using ResponseUserDto = ESOF.WebApp.WebAPI.Controller.Dto.Users.ResponseUserDto;

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
    
        [HttpGet("")]
        public ActionResult<List<ResponseUserDto>> GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseUserDto> GetUserById(Guid id)
        {
            try
            {
                return Ok(_userService.getUserById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult<User> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var createdUser = _userService.CreateUser(createUserDto);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update/{id}")]
        public ActionResult<ResponseUserDto> UpdateUser(Guid id,UpdateUserDto updateUserDto)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(id, updateUserDto);
                return Ok(updatedUser); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
}