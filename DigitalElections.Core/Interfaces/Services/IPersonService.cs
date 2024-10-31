using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Services.Base;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.Interfaces.Services;

public interface IPersonService : IService<PersonDTO>
{
    Task<List<PersonNeighborhoodDTO>> GetPersonByNeighborhood();
    Task<List<Person>> GetTransferVoters(); 
}