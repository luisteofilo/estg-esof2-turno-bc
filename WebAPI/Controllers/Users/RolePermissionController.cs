using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]

public class RolePermissionController : ControllerBase
{
    private readonly RolePermissionsService _rolePermissionsService;

        public RolePermissionController()
        {
            _rolePermissionsService = new RolePermissionsService(new ApplicationDbContext());
        }
    
        [HttpGet("")]
        public ActionResult<List<ResponseRolePermissionsDto>> GetAllRolesPermissions()
        {
            try
            {
                return Ok(_rolePermissionsService.GetAllRolePermissions());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseRolePermissionsDto> GetRolePermissionsById(Guid id)
        {
            try
            {
                return Ok(_rolePermissionsService.getRolePermissionById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult<RolePermission> CreateRolePermission([FromBody] CreateRolePermissionsDto createRolePermissionDto)
        {
            try
            {
                var createdRolePermission = _rolePermissionsService.CreateRolePermission(createRolePermissionDto);
                return CreatedAtAction(nameof(GetRolePermissionsById), new { id = createdRolePermission.RoleId }, createdRolePermission);
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
        public ActionResult<ResponseRolePermissionsDto> UpdateRolePermission(Guid id,UpdateRolePermissionsDto updateRolePermissionDto)
        {
            try
            {
                var updatedRolePermission = _rolePermissionsService.UpdateRolePermission(id, updateRolePermissionDto);
                return Ok(updatedRolePermission); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteRolePermission(Guid id)
        {
            try
            {
                _rolePermissionsService.DeleteRolePermission(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
}
