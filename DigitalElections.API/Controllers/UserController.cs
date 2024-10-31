using AutoMapper;
using DigitalElections.API.Controllers.Base;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalElections.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : BaseController<UserDTO, IUserService>
{
    public UserController(ILogger<Users> logger, IMapper mapper, IUserService service) : base(logger, mapper, service)
    { }

    [AllowAnonymous]
    public override async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO dto)
    {
        return await base.Post(dto);
    }

    [Authorize(Roles = "Admin")]
    public override Task<ActionResult<List<UserDTO>>> All()
    {
        return base.All();
    }
    
    [HttpGet("leader-voters")]
    public async Task<ActionResult<List<LeaderRegistersDTO>>> CountVotersByLeader()
    {
        return await _service.CountVotersByLeaders();
    }
}