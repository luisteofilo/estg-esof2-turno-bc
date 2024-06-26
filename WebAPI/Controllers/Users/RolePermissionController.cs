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

        [HttpGet("{roleId}/{permissionId}")]
        public ActionResult<ResponseRolePermissionsDto> GetRolePermissionsById(Guid roleId, Guid permissionId)
        {
            try
            {
                return Ok(_rolePermissionsService.getRolePermissionById(roleId, permissionId));
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


        [HttpPut("update/{roleId}/{permissionId}")]
        public ActionResult<ResponseRolePermissionsDto> UpdateRolePermission(Guid roleId, Guid permissionId,UpdateRolePermissionsDto updateRolePermissionDto)
        {
            try
            {
                var updatedRolePermission = _rolePermissionsService.UpdateRolePermission(roleId, permissionId, updateRolePermissionDto);
                return Ok(updatedRolePermission); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete/{roleId}/{permissionId}")]
        public ActionResult DeleteRolePermission(Guid roleId, Guid permissionId)
        {
            try
            {
                _rolePermissionsService.DeleteRolePermission(roleId, permissionId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
}
