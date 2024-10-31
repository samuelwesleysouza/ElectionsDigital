using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Domain.Entities;
using Logar.Domain.Services.Base;

namespace DigitalElections.Domain.Services;

public class SchoolService : BaseService<SchoolDTO, School>, ISchoolService
{
    public SchoolService(IRepository<School> repository, IMapper mapper) : base(repository, mapper)
    {}
}