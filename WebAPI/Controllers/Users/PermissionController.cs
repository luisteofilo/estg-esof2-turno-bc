using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController: ControllerBase
{
    private readonly PermissonService _permissonService;
    
    public PermissionController()
    {
        _permissonService = new PermissonService(new ApplicationDbContext());
    }

    [HttpGet("")]
    public ActionResult<List<ResponsePermissionsDto>> GetAllPermissions()
    {
        try
        {
            return Ok(_permissonService.getAllPermissions());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<ResponsePermissionsDto> GetPermissionById(Guid id)
    {
        try
        {
            return Ok(_permissonService.GetPermissionById(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("create")]
    public ActionResult<ResponseUserDto> CreatePermission([FromBody] CreatePermissionsDto createPermissionsDto)
    {
        try
        {
            var createdPermission = _permissonService.CreatePermission(createPermissionsDto);
            return CreatedAtAction(nameof(GetPermissionById), new { id = createdPermission.PermissionId },
                createdPermission);
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("update/{id}")]
    public ActionResult<ResponsePermissionsDto> UpdatePermission(Guid id, UpdatePermissionDto updatePermissionDto)
    {
        try
        {
            var updatedPermission = _permissonService.UpdatePermission(id, updatePermissionDto);
            return Ok(updatedPermission);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<ResponsePermissionsDto> DeletePermission(Guid id)
    {
        try
        {
            _permissonService.DeletePermission(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}