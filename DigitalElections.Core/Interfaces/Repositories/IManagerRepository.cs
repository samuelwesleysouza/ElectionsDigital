using DigitalElections.Domain.Entities;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.Interfaces.Repositories;

public interface IManagerRepository : IRepository<Manager>
{
    Task<List<Users>> GetLeaders();
    Task<Manager?> GetManagerById(long? id);
}