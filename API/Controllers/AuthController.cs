using Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDto userLoginDto)
    {
        var userToLogin = await _authService.Login(userLoginDto);
        if (!userToLogin.Success)
        {
            return BadRequest(userToLogin);
        }

        var result = await _authService.CreateAccessToken(userToLogin.Data);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(UserRegisterDto userRegisterDto)
    {
        var registerResult = await _authService.Register(userRegisterDto);
        if (registerResult.Success)
        {
            var result = await _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        return BadRequest(registerResult);
    }
}