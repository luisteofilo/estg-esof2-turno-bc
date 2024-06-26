using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.Controller.Dto.Users;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESOF.WebApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;
    
    public RoleController()
    {
        _roleService = new RoleService(new ApplicationDbContext());
    }

    [HttpGet("")]
    public ActionResult<List<ResponseRolesDto>> GetAllRole()
    {
        try
        {
            return Ok(_roleService.GetAllRoles());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<ResponseRolesDto> GetRoleById(Guid id)
    {
        try
        {
            return Ok(_roleService.GetRoleById(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("create")]
    public ActionResult<ResponseRolesDto> CreateRole(CreateRolesDto createRolesDto)
    {
        try
        {
            var createdRole = _roleService.CreateRole(createRolesDto);
            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.RoleId }, createdRole);
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
    public ActionResult<ResponseRolesDto> UpdateRole(Guid id, UpdateRolesDto updateRolesDto)
    {
        try
        {
            return Ok(_roleService.UpdateRole(id, updateRolesDto));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<ResponseRolesDto> DeleteRole(Guid id)
    {
        try
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}