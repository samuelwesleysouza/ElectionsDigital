using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.Interfaces.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<List<PersonNeighborhoodDTO>> GetPersonByNeighborhood();
    Task<List<Person>> GetTransferVoters();
}