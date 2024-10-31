using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.Interfaces.Repositories;

public interface IUserRepository : IRepository<Users>
{
    Task<Users?> UserEmail(string email);
    Task<List<LeaderRegistersDTO>> GetLeaderAndYourPersonsRegister();
}