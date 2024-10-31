using AutoMapper;
using DigitalElections.API.Controllers.Base;
using DigitalElections.Core.DTOs;
using DigitalElections.Domain.Entities;
using DigitalElections.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalElections.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagerController : BaseController<ManagerDTO, IManagerService>
{
    public ManagerController(ILogger<Manager> logger, IMapper mapper, IManagerService service) : base(logger, mapper, service)
    { }

    [HttpPost]
    [AllowAnonymous]
    public override async Task<ActionResult<ManagerDTO>> Post([FromBody] ManagerDTO dto)
    {
        var result = await _service.Create(dto);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet("leaders")]
    public async Task<ActionResult<List<UserDTO>>> GetLeaders()
    {
        var result = await _service.GetLeaders();

        return Ok(result);
    }
}
