using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Services.Base;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.Interfaces.Services;

public interface IManagerService : IService<ManagerDTO>
{
    Task<List<Users>> GetLeaders();
}