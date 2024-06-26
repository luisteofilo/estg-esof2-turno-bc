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

        [HttpGet("{id}")]
        public ActionResult<ResponseUserRolesDto> GetUserRoleById(Guid id)
        {
            try
            {
                return Ok(_userRolesService.getUserRolesById(id));
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


        [HttpPut("update/{id}")]
        public ActionResult<ResponseUserRolesDto> UpdateUserRole(Guid id,UpdateUserRolesDto updateUserRolesDto)
        {
            try
            {
                var updatedUserRole = _userRolesService.UpdateUserRoles(id, updateUserRolesDto);
                return Ok(updatedUserRole); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteUserRole(Guid id)
        {
            try
            {
                _userRolesService.DeleteUserRoles(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
}