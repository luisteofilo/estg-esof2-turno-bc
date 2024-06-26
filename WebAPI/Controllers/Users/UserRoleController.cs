using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]

public class UserRoleController : ControllerBase
{
    private readonly UserRolesService _userRolesService;

        public UserRoleController()
        {
            _userRolesService = new UserRolesService(new ApplicationDbContext());
        }
    
        [HttpGet("")]
        public ActionResult<List<ResponseUserRolesDto>> GetAllUserRoles()
        {
            try
            {
                return Ok(_userRolesService.GetAllUserRoles());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId}/{roleId}")]
        public ActionResult<ResponseUserRolesDto> GetUserRoleById(Guid userId, Guid roleId)
        {
            try
            {
                return Ok(_userRolesService.getUserRolesById(userId, roleId));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult<UserRole> CreateUserRole([FromBody] CreateUserRolesDto createUserRolesDto)
        {
            try
            {
                var createdUserRole = _userRolesService.CreateUserRole(createUserRolesDto);
                return CreatedAtAction(nameof(GetUserRoleById), new { id = createdUserRole.UserId }, createdUserRole);
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


        [HttpPut("update/{userId}/{roleId}")]
        public ActionResult<ResponseUserRolesDto> UpdateUserRole(Guid userId, Guid roleId,UpdateUserRolesDto updateUserRolesDto)
        {
            try
            {
                var updatedUserRole = _userRolesService.UpdateUserRoles(userId, roleId, updateUserRolesDto);
                return Ok(updatedUserRole); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{userId}/{roleId}")]
        public ActionResult DeleteUserRole(Guid userId, Guid roleId)
        {
            try
            {
                _userRolesService.DeleteUserRoles(userId, roleId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
}