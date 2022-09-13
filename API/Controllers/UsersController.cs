using Entity.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using Service.Aspects.Security;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController:ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    // [SecuredAction("admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    
    [SecuredAction("admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    
    // [SecuredAction("admin")]
    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser(AddRoleToUserDto dto)
    {
        var result = await _service.AddRoleToUserAsync(dto.UserId, dto.OperationClaimId);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}