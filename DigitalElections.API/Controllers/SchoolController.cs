using AutoMapper;
using DigitalElections.API.Controllers.Base;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalElections.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController : BaseController<SchoolDTO, ISchoolService>
{
    public SchoolController(ILogger<School> logger, IMapper mapper, ISchoolService service) : base(logger, mapper, service)
    { }
}