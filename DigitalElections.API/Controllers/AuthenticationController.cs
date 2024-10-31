using DigitalElections.Core.DTOs.Response;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalElections.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> UserLogin([FromBody] LoginDTO login)
    {
        var result = await _authenticationService.Login(login);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPost("manager-login")]
    public async Task<ActionResult<LoginResponseDTO>> ManagerLogin([FromBody] LoginDTO login)
    {
        var result = await _authenticationService.LoginWithManagerAccount(login);

        if (result is null)
        {
            return NotFound();
        }


        return Ok(result);
    }
}
