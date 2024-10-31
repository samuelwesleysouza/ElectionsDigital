using AutoMapper;
using DigitalElections.API.Controllers.Base;
using DigitalElections.Core.DTOs;
using DigitalElections.Domain.Entities;
using DigitalElections.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalElections.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HelpFriendController : BaseController<HelpFriendDTO, IHelpFriendService>
{
    public HelpFriendController(ILogger<HelpFriend> logger, IMapper mapper, IHelpFriendService service) : base(logger, mapper, service)
    { }
}